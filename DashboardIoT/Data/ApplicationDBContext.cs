using DashboardIoT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardIoT.Data
{
	public class ApplicationDBContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite(Settings.AppSettings.SqlLiteConnectionString);
			}
		}

		public DbSet<Alarm> Alarms { get; set; }
		public DbSet<AlarmState> AlarmStates { get; set; }
		public DbSet<ArmedState> ArmedStates { get; set; }
		public DbSet<CalibratedDistance> CalibratedDistances { get; set; }
		public DbSet<SilentState> SilentStates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Alarm>().ToTable("Alarms").HasIndex(a => a.Id).IsUnique();
			modelBuilder.Entity<AlarmState>().ToTable("AlarmStates").HasIndex(a => a.Id).IsUnique();
			modelBuilder.Entity<ArmedState>().ToTable("ArmedStates").HasIndex(s => s.Id).IsUnique();
			modelBuilder.Entity<CalibratedDistance>().ToTable("CalibratedDistances").HasIndex(d => d.Id).IsUnique();
			modelBuilder.Entity<SilentState>().ToTable("SilentStates").HasIndex(d => d.Id).IsUnique();
		}
	}
}
