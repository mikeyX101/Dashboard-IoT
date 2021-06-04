using System;
using DashboardIoT.Models;

namespace DashboardIoT.Data
{
	public partial class DataOperations
	{
		public void AddAlarmNow()
		{
			DB.Alarms.Add(new Alarm(DateTime.UtcNow));
			DB.SaveChanges();
		}

		public void AddAlarmState(AlarmState alarm)
		{
			DB.AlarmStates.Add(alarm);
			DB.SaveChanges();
		}
		
	}
}
