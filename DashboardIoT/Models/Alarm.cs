using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardIoT.Models
{
	public class Alarm
	{
        public Alarm() { }
        public Alarm(DateTime time)
		{
            Time = time;
		}

        [Key]
        [Required]
        [Column("id")]
        public uint Id { get; set; }

        [Required]
        [Column("time")]
        public DateTime Time { get; set; }
    }
}
