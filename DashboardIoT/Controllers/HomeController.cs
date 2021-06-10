using DashboardIoT.Models;
using DashboardIoT.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MQTTnet.Client.Publishing;
using MQTTnet.Server;
using MQTTnet.Server.Status;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

		[HttpPost]
		public async Task<IActionResult> Data()
		{
			Data.DataOperations db = new();

			IList<AlarmState> alarmStates = db.GetAlarmStates().ToList();
			IList<SilentState> silentStates = db.GetSilentStates().ToList();
			IList<ArmedState> armedStates = db.GetArmedStates().ToList();

			IList<IMqttClientStatus> mqttClients = await _mqtt.GetClientStatusAsync();
			bool systemConnected = false;
			foreach (IMqttClientStatus client in mqttClients)
			{
				if (client.ClientId == "AlarmSystem")
				{
					systemConnected = true;
					break;
				}
			}

			DashboardData data = new(
				db.GetAlarms().ToList(),
				alarmStates,
				silentStates,
				armedStates,
				db.GetCalibratedDistances().LastOrDefault()?.Distance ?? -1,
				alarmStates.LastOrDefault()?.RecordedState.GetBoolValue(),
				silentStates.LastOrDefault()?.RecordedState.GetBoolValue(),
				armedStates.LastOrDefault()?.RecordedState.GetBoolValue(),
				systemConnected
			);

			return Json(data);
		}

		public async Task<IActionResult> Disarm()
		{
			MqttClientPublishResult result = await new Data.MqttDataOperations(_mqtt).Disarm();
			if (result.ReasonCode == MqttClientPublishReasonCode.Success)
			{
				await Task.Delay(TimeSpan.FromMilliseconds(400));
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		public async Task<IActionResult> ToggleArmed()
		{
			Data.DataOperations db = new();
			Data.MqttDataOperations mqttDataOperations = new(_mqtt);

			ArmedState state = db.GetArmedStates().LastOrDefault();
			if (state != null && state.RecordedState == OnOffState.On)
			{
				ArmedState newState = new(DateTime.UtcNow, OnOffState.Off);
				MqttClientPublishResult result = await mqttDataOperations.PublishArmedState(newState);
				if (result.ReasonCode == MqttClientPublishReasonCode.Success)
				{
					db.AddArmedState(newState);

					if (db.GetAlarmStates().LastOrDefault().RecordedState == OnOffState.On)
					{
						await mqttDataOperations.Disarm();
					}
					await Task.Delay(TimeSpan.FromMilliseconds(400));

					return Ok();
				}
			}
			else if (state != null && state.RecordedState == OnOffState.Off)
			{
				ArmedState newState = new(DateTime.UtcNow, OnOffState.On);
				MqttClientPublishResult result = await mqttDataOperations.PublishArmedState(newState);
				if (result.ReasonCode == MqttClientPublishReasonCode.Success)
				{
					db.AddArmedState(newState);
					await Task.Delay(TimeSpan.FromMilliseconds(400));
					return Ok();
				}
			}
			return BadRequest();
		}

		public async Task<IActionResult> ToggleSilent()
		{
			Data.DataOperations db = new();
			Data.MqttDataOperations mqttDataOperations = new(_mqtt);

			SilentState state = db.GetSilentStates().LastOrDefault();
			if (state != null && state.RecordedState == OnOffState.On)
			{
				SilentState newState = new(DateTime.UtcNow, OnOffState.Off);
				MqttClientPublishResult result = await mqttDataOperations.PublishSilentState(newState);
				if (result.ReasonCode == MqttClientPublishReasonCode.Success)
				{
					db.AddSilentState(newState);
					await Task.Delay(TimeSpan.FromMilliseconds(400));
					return Ok();
				}
			}
			else if (state != null && state.RecordedState == OnOffState.Off)
			{
				SilentState newState = new(DateTime.UtcNow, OnOffState.On);
				MqttClientPublishResult result = await mqttDataOperations.PublishSilentState(newState);
				if (result.ReasonCode == MqttClientPublishReasonCode.Success)
				{
					db.AddSilentState(newState);
					await Task.Delay(TimeSpan.FromMilliseconds(400));
					return Ok();
				}
			}
			return BadRequest();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
