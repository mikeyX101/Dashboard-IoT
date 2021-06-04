using MQTTnet.AspNetCore;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashboardIoT.Extensions;

namespace DashboardIoT.Services
{
	public class MqttService : IMqttServerClientConnectedHandler, IMqttServerApplicationMessageInterceptor, IMqttServerConnectionValidator, IMqttServerClientDisconnectedHandler
	{
		public IMqttServer MQTT { get; private set; }

		public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
		{
			options.WithConnectionValidator(this);
			options.WithApplicationMessageInterceptor(this);
		}

		public void ConfigureMqttServer(IMqttServer mqtt)
		{
			MQTT = mqtt;
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
			if (context.ClientId.Length < 10)
			{
				context.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
				Console.WriteLine("Invalid client id");
				return Task.FromException(new ArgumentException("Invalid client id"));
			}

			if (false && context.Username != "mySecretUser")
			{
				context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
				Console.WriteLine("Invalid Username");
				return Task.FromException(new UnauthorizedAccessException("Invalid Username"));
			}

			if (false && context.Password != "mySecretPassword")
			{
				context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
				Console.WriteLine("Invalid Password");
				return Task.FromException(new UnauthorizedAccessException("Invalid Password"));
			}

			context.ReasonCode = MqttConnectReasonCode.Success;
			return Task.CompletedTask;
		}
	}
}
