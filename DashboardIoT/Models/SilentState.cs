using System;

namespace DashboardIoT.Models
{
	public class SilentState : State
	{
        public SilentState() : base() { }
        public SilentState(DateTime time, OnOffState state) : base(time, state) { }
    }
}
