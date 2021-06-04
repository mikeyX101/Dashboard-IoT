using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DashboardIoT.Extensions;
using DashboardIoT.Models;

namespace DashboardIoT.Data
{
	public partial class DataOperations
	{
		public ApplicationDBContext DB;

		public DataOperations()
		{
			DB = new ApplicationDBContext();
		}
		public DataOperations(ApplicationDBContext db)
		{
			DB = db;
		}

		public void HandleMqttApplicationMessage(MQTTnet.MqttApplicationMessage message)
		{
			if (message.Topic == "alarm" && message.PayloadToUTF8String() == "triggered")
			{
				AddAlarmNow();
			}
			else if (message.Topic == "alarmState" && OnOffStateHelper.TryParse(message.PayloadToUTF8String(), out OnOffState alarmState) && alarmState != OnOffState.Invalid)
			{
				AddAlarmState(new AlarmState(DateTime.UtcNow, alarmState));
			}
			else if (message.Topic == "armedState" && OnOffStateHelper.TryParse(message.PayloadToUTF8String(), out OnOffState armedState) && armedState != OnOffState.Invalid)
			{
				AddArmedState(new ArmedState(DateTime.UtcNow, armedState));
			}
			else if (message.Topic == "silentState" && OnOffStateHelper.TryParse(message.PayloadToUTF8String(), out OnOffState silentState) && silentState != OnOffState.Invalid)
			{
				AddSilentState(new SilentState(DateTime.UtcNow, silentState));
			}
			else if (message.Topic == "calibratedDistance" && float.TryParse(message.PayloadToUTF8String(), NumberStyles.Any, CultureInfo.InvariantCulture, out float calibratedDistance))
			{
				AddCalibratedDistance(new CalibratedDistance(DateTime.UtcNow, calibratedDistance));
			}
		}
	}
}
