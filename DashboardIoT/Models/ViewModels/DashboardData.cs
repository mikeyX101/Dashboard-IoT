using Newtonsoft.Json;
using System.Collections.Generic;

namespace DashboardIoT.Models.ViewModels
{
	public class DashboardData
	{
		public DashboardData(
			IList<Alarm> alarmData, 
			IList<AlarmState> alarmStateData, 
			IList<SilentState> silentStateData, 
			IList<ArmedState> armedStateData,
			float lastCalibratedDistance,
			bool? lastAlarmState,
			bool? lastSilentState,
			bool? lastArmedState,
			bool systemConnected)
		{
			AlarmData = alarmData;
			AlarmStateData = alarmStateData;
			SilentStateData = silentStateData;
			ArmedStateData = armedStateData;

			LastCalibratedDistance = lastCalibratedDistance;
			LastAlarmState = lastAlarmState;
			LastSilentState = lastSilentState;
			LastArmedState = lastArmedState;

			SystemConnected = systemConnected;
		}

		[JsonProperty(PropertyName = "alarmData")]
		public IList<Alarm> AlarmData { get; set; }
		[JsonProperty(PropertyName = "alarmStateData")]
		public IList<AlarmState> AlarmStateData { get; set; }
		[JsonProperty(PropertyName = "silentStateData")]
		public IList<SilentState> SilentStateData { get; set; }
		[JsonProperty(PropertyName = "armedStateData")]
		public IList<ArmedState> ArmedStateData { get; set; }

		[JsonProperty(PropertyName = "lastCalibratedDistance")]
		public float LastCalibratedDistance { get; set; }
		[JsonProperty(PropertyName = "lastAlarmState")]
		public bool? LastAlarmState { get; set; }
		[JsonProperty(PropertyName = "lastSilentState")]
		public bool? LastSilentState { get; set; }
		[JsonProperty(PropertyName = "lastArmedState")]
		public bool? LastArmedState { get; set; }

		[JsonProperty(PropertyName = "systemConnected")]
		public bool SystemConnected { get; set; }
	}
}
