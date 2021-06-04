using DashboardIoT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MQTTnet.Server;
using System.Diagnostics;

namespace DashboardIoT.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMqttServer _mqtt;

		public HomeController(ILogger<HomeController> logger, IMqttServer mqtt)
		{
			_logger = logger;
			_mqtt = mqtt;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Disarm()
		{
			_mqtt.PublishAsync(new MQTTnet.MqttApplicationMessage()
			{
				Topic = "systemState",
				Payload = System.Text.Encoding.UTF8.GetBytes("off,true"),
				Retain = true
			});

			return Ok();
		}
	}
}
