using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using MQTTnet.AspNetCore.Extensions;

namespace DashboardIoT
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (!System.IO.Directory.Exists("App_Data"))
			{
				System.IO.Directory.CreateDirectory("App_Data");
			}

			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseKestrel(options =>
					{
						options.ListenAnyIP(5000);
						options.ListenAnyIP(5001);
						options.ListenAnyIP(1883, listenOptions => listenOptions.UseMqtt()); // 8883 for secured
					});
					webBuilder.UseStartup<Startup>();
				});
	}
}
