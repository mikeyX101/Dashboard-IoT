using DashboardIoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
		
		public IEnumerable<Alarm> GetAlarms(bool reverseOrder = false)
		{
			IEnumerable<Alarm> alarms = DB.Alarms;
			if (reverseOrder)
			{
				alarms = alarms.OrderByDescending(a => a.Time);
			}
			else
			{
				alarms = alarms.OrderBy(a => a.Time);
			}
			return alarms;
		}
		public IEnumerable<Alarm> GetAlarms(DateTime start, DateTime end, bool reverseOrder = false)
		{
			IEnumerable<Alarm> alarms = DB.Alarms.Where(a => a.Time >= start && a.Time <= end);
			if (reverseOrder)
			{
				alarms = alarms.OrderByDescending(a => a.Time);
			}
			else
			{
				alarms = alarms.OrderBy(a => a.Time);
			}
			return alarms;
		}

		public IEnumerable<AlarmState> GetAlarmStates(bool reverseOrder = false)
		{
			IEnumerable<AlarmState> alarmStates = DB.AlarmStates;
			if (reverseOrder)
			{
				alarmStates = alarmStates.OrderByDescending(a => a.Time);
			}
			else
			{
				alarmStates = alarmStates.OrderBy(a => a.Time);
			}
			return alarmStates;
		}
		public IEnumerable<AlarmState> GetAlarmStates(DateTime start, DateTime end, bool reverseOrder = false)
		{
			IEnumerable<AlarmState> alarmStates = DB.AlarmStates.Where(a => a.Time >= start && a.Time <= end);
			if (reverseOrder)
			{
				alarmStates = alarmStates.OrderByDescending(a => a.Time);
			}
			else
			{
				alarmStates = alarmStates.OrderBy(a => a.Time);
			}
			return alarmStates;
		}
	}
}
