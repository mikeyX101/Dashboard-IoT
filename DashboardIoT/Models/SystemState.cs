using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Models
{
	public class SystemState
	{
        public SystemState() { }
        public SystemState(DateTime time, OnOffState state, bool silentMode)
        {
            Time = time;
            State = state;
            SilentMode = silentMode;
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
        public OnOffState State { get; set; }

        [Required]
        [Column("silentModeActive")]
        public bool SilentMode { get; set; }

        public static bool TryGetArgs(string message, out OnOffState state, out bool? isSilent)
		{
            state = OnOffState.Invalid;
            isSilent = null;

            bool valid = false;
            string[] args = message.Split(',');
            if (args.Length == 2 && 
                OnOffStateHelper.TryParse(args[0], out OnOffState systemState) && systemState != OnOffState.Invalid &&
                bool.TryParse(args[1], out bool silent))
			{
                valid = true;
                state = systemState;
                isSilent = silent;
            }

            return valid;
        }
    }
}
