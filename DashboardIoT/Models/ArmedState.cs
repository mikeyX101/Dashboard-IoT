using System;

namespace DashboardIoT.Models
{
	public class ArmedState : State
    {
        public ArmedState() : base() { }
        public ArmedState(DateTime time, OnOffState state) : base(time, state) { }
    }
}
