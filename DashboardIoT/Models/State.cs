﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Models
{
    public abstract class State
    {
        public State() { }
        public State(DateTime time, OnOffState state)
        {
            Time = time;
            RecordedState = state;
        }

        [Key]
        [Required]
        [Column("id")]
        public uint Id { get; set; }

        [Required]
        [Column("time")]
        public DateTime Time { get; set; }

        [Required]
        [Column("state")]
        public OnOffState RecordedState { get; set; }
    }
}
