using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using MQTTnet.AspNetCore.Extensions;
using System.Net;

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
						options.Listen(IPAddress.Any, 5001, httpsOptions =>
						{
							httpsOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
							httpsOptions.UseHttps(System.Environment.GetEnvironmentVariable("IOT_HTTPS_CERT"), System.Environment.GetEnvironmentVariable("IOT_HTTPS_PASS"));
						});
						options.ListenAnyIP(8883, listenOptions => listenOptions.UseMqtt()); // 1883 for unsecured, 8883 for secured
					});
					webBuilder.UseStartup<Startup>();
				});
	}
}
