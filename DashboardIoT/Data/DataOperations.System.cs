using System;
using DashboardIoT.Models;

namespace DashboardIoT.Data
{
	public partial class DataOperations
	{
		public void AddSystemState(SystemState systemState)
		{
			DB.SystemStates.Add(systemState);
			DB.SaveChanges();
		}

		public void AddCalibratedDistance(CalibratedDistance distance)
		{
			DB.CalibratedDistances.Add(distance);
			DB.SaveChanges();
		}
	}
}
