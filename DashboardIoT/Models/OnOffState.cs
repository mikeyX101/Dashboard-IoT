namespace DashboardIoT.Models
{
	public enum OnOffState
	{
		ON = 2, 
		OFF = 1, 
		Invalid = 0
	}

	public static class OnOffStateHelper
	{
		public static bool TryParse(string s, out OnOffState state)
		{
			string upperString = s.ToUpper();
			state = upperString switch
			{
				"ON" => OnOffState.ON,
				"OFF" => OnOffState.OFF,
				_ => OnOffState.Invalid
			};
			return state != OnOffState.Invalid;
		}
	}
}
