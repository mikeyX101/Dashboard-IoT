using MQTTnet;

namespace DashboardIoT.Extensions
{
	internal static class ApplicationMessageExtensions
	{
		public static string PayloadToUTF8String(this MqttApplicationMessage message)
		{
			return System.Text.Encoding.UTF8.GetString(message.Payload);
		}
	}
}
