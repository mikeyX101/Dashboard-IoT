using Microsoft.Extensions.Configuration;
using System;

namespace DashboardIoT
{
	public class Settings
	{
		private static Settings appSettings;
		public static Settings AppSettings {
			get {
				if (appSettings != null)
				{
					return appSettings;
				}
				throw new InvalidOperationException("Settings must be initiated before using it. Use Settings.Initiate() on app startup.");
			}
		}

		public readonly string SqlLiteConnectionString;

		private Settings(IConfiguration config)
		{
			SqlLiteConnectionString = config.GetValue<string>("DefaultConnection");
		}

		public static void Initiate(IConfiguration config)
		{
			appSettings = new Settings(config);
		}
	}
}
