﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Models
{
	public class CalibratedDistance
	{
        public CalibratedDistance() { }
        public CalibratedDistance(DateTime time, float distance)
        {
            Time = time;
            Distance = distance;
        }

        [Key]
        [Required]
        [Column("id")]
        public uint Id { get; set; }

        [Required]
        [Column("time")]
        public DateTime Time { get; set; }

        [Required]
        [Column("calibratedDistance")]
        public float Distance { get; set; }
    }
}
