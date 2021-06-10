using DashboardIoT.Extensions;
using MQTTnet.AspNetCore;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DashboardIoT.Services
{
	public class MqttService : IMqttServerClientConnectedHandler, IMqttServerApplicationMessageInterceptor, IMqttServerConnectionValidator, IMqttServerClientDisconnectedHandler
	{
		private static string AllowedClientId => "AlarmSystem";

		public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
		{
			options.WithoutDefaultEndpoint()
				.WithEncryptedEndpoint()
				.WithEncryptedEndpointPort(8883)
				.WithEncryptionCertificate(new X509Certificate2(Environment.GetEnvironmentVariable("IOT_MQTT_CERT"), Environment.GetEnvironmentVariable("IOT_MQTT_PASS"), X509KeyStorageFlags.Exportable))
				.WithEncryptionSslProtocol(System.Security.Authentication.SslProtocols.Tls12)

				.WithConnectionValidator(this)
				.WithApplicationMessageInterceptor(this);
		}

		public void ConfigureMqttServer(IMqttServer mqtt)
		{
			mqtt.ClientConnectedHandler = this;
			mqtt.ClientDisconnectedHandler = this;
		}

		public Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
		{
			Console.WriteLine($"Client {eventArgs.ClientId} connected.");
			return Task.CompletedTask;
		}

		public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
		{
			Console.WriteLine($"Message with topic \"{context.ApplicationMessage.Topic}\" and payload \"{context.ApplicationMessage.PayloadToUTF8String()}\" got published on server.");

			Data.DataOperations db = new();
			db.HandleMqttApplicationMessage(context.ApplicationMessage);

			return Task.CompletedTask;
		}

		public Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
		{
			Console.WriteLine($"Client {eventArgs.ClientId} disconnected.");
			return Task.CompletedTask;
		}

		public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
		{
			Data.DataOperations db = new();
			Models.MqttUser mqttUser = db.GetMqttUserByClientId(AllowedClientId);
			if (context.ClientId != mqttUser.ClientId)
			{
				context.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
				Console.WriteLine("Invalid ClientId");
			}

			if (context.Username != mqttUser.Username)
			{
				context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
				Console.WriteLine("Invalid Username");
			}

			if (!Utils.Hashing.TryHash(context.Password, mqttUser.PasswordSalt, out string password) || password != mqttUser.Password)
			{
				context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
				Console.WriteLine("Invalid Password");
			}

			context.ReasonCode = MqttConnectReasonCode.Success;
			return Task.CompletedTask;
		}
	}
}
