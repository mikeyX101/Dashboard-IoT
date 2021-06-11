using DashboardIoT.Extensions;
using DashboardIoT.Models;
using MQTTnet;
using MQTTnet.Client.Publishing;
using System.Threading.Tasks;

namespace DashboardIoT.Data
{
	public class MqttDataOperations
	{
		private readonly MQTTnet.Server.IMqttServer Server;

		public MqttDataOperations(MQTTnet.Server.IMqttServer server)
		{
			Server = server;
		}

		public Task<MqttClientPublishResult> Disarm()
		{
			return Server.PublishAsync(new MqttApplicationMessage()
			{
				Topic = "alarmState",
				Payload = "off".ToUTF8Bytes(),
				Retain = true
			}, System.Threading.CancellationToken.None);
		}

		public Task<MqttClientPublishResult> PublishArmedState(ArmedState state)
		{
			return Server.PublishAsync(new MqttApplicationMessage()
			{
				Topic = "armedState",
				Payload = state.RecordedState.ToString().ToLower().ToUTF8Bytes(),
				Retain = true
			}, System.Threading.CancellationToken.None);
		}

		public Task<MqttClientPublishResult> PublishSilentState(SilentState state)
		{
			return Server.PublishAsync(new MqttApplicationMessage()
			{
				Topic = "silentState",
				Payload = state.RecordedState.ToString().ToLower().ToUTF8Bytes(),
				Retain = true
			}, System.Threading.CancellationToken.None);
		}
	}
}
