using System;

namespace DashboardIoT.Models
{
	public class AlarmState : State
    {
        public AlarmState() : base() { }
        public AlarmState(DateTime time, OnOffState state) : base(time, state) { }
    }
}
