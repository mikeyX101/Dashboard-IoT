using DashboardIoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardIoT.Data
{
	public partial class DataOperations
	{
		public void AddArmedState(ArmedState armedState)
		{
			DB.ArmedStates.Add(armedState);
			DB.SaveChanges();
		}

		public void AddCalibratedDistance(CalibratedDistance distance)
		{
			DB.CalibratedDistances.Add(distance);
			DB.SaveChanges();
		}

		public void AddSilentState(SilentState silentState)
		{
			DB.SilentStates.Add(silentState);
			DB.SaveChanges();
		}

		public IEnumerable<ArmedState> GetArmedStates(bool reverseOrder = false)
		{
			IEnumerable<ArmedState> armedStates = DB.ArmedStates;
			if (reverseOrder)
			{
				armedStates = armedStates.OrderByDescending(a => a.Time);
			}
			else
			{
				armedStates = armedStates.OrderBy(a => a.Time);
			}
			return armedStates;
		}
		public IEnumerable<ArmedState> GetArmedStates(DateTime start, DateTime end, bool reverseOrder = false)
		{
			IEnumerable<ArmedState> armedStates = DB.ArmedStates.Where(a => a.Time >= start && a.Time <= end);
			if (reverseOrder)
			{
				armedStates = armedStates.OrderByDescending(a => a.Time);
			}
			else
			{
				armedStates = armedStates.OrderBy(a => a.Time);
			}
			return armedStates;
		}

		public IEnumerable<CalibratedDistance> GetCalibratedDistances(bool reverseOrder = false)
		{
			IEnumerable<CalibratedDistance> calibratedDistances = DB.CalibratedDistances;
			if (reverseOrder)
			{
				calibratedDistances = calibratedDistances.OrderByDescending(c => c.Time);
			}
			else
			{
				calibratedDistances = calibratedDistances.OrderBy(c => c.Time);
			}
			return calibratedDistances;
		}
		public IEnumerable<CalibratedDistance> GetCalibratedDistances(DateTime start, DateTime end, bool reverseOrder = false)
		{
			IEnumerable<CalibratedDistance> calibratedDistances = DB.CalibratedDistances.Where(c => c.Time >= start && c.Time <= end);
			if (reverseOrder)
			{
				calibratedDistances = calibratedDistances.OrderByDescending(c => c.Time);
			}
			else
			{
				calibratedDistances = calibratedDistances.OrderBy(c => c.Time);
			}
			return calibratedDistances;
		}

		public IEnumerable<SilentState> GetSilentStates(bool reverseOrder = false)
		{
			IEnumerable<SilentState> silentStates = DB.SilentStates;
			if (reverseOrder)
			{
				silentStates = silentStates.OrderByDescending(s => s.Time);
			}
			else
			{
				silentStates = silentStates.OrderBy(s => s.Time);
			}
			return silentStates;
		}
		public IEnumerable<SilentState> GetSilentStates(DateTime start, DateTime end, bool reverseOrder = false)
		{
			IEnumerable<SilentState> silentStates = DB.SilentStates.Where(s => s.Time >= start && s.Time <= end);
			if (reverseOrder)
			{
				silentStates = silentStates.OrderByDescending(s => s.Time);
			}
			else
			{
				silentStates = silentStates.OrderBy(s => s.Time);
			}
			return silentStates;
		}
	}
}
