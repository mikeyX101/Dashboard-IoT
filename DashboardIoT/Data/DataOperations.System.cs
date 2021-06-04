using System;
using DashboardIoT.Models;

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
	}
}
