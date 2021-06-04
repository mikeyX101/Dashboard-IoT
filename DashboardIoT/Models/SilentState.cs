using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Models
{
	public class SilentState : State
	{
        public SilentState() : base() { }
        public SilentState(DateTime time, OnOffState state) : base(time, state) { }
    }
}
