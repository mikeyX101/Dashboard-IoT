using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Models
{
    public class ArmedState : State
    {
        public ArmedState() : base() { }
        public ArmedState(DateTime time, OnOffState state) : base(time, state) { }
    }
}
