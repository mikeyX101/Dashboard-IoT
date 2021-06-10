namespace DashboardIoT.Models
{
	public enum OnOffState
	{
		Off = 0,
		On = 1, 
		Invalid = int.MaxValue
	}

	public static class OnOffStateExtensions
	{
		public static bool? GetBoolValue(this OnOffState state)
		{
			return state switch
			{
				OnOffState.On => true,
				OnOffState.Off => false,
				OnOffState.Invalid or _ => null
			};
		}

		public static int GetValue(this OnOffState state)
		{
			return (int)state;
		}
	}

	public static class OnOffStateHelper
	{
		public static bool TryParse(string s, out OnOffState state)
		{
			string upperString = s.ToUpper();
			state = upperString switch
			{
				"ON" => OnOffState.On,
				"OFF" => OnOffState.Off,
				_ => OnOffState.Invalid
			};
			return state != OnOffState.Invalid;
		}
	}
}
