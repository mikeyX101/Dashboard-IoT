using DashboardIoT.Models;
using Microsoft.EntityFrameworkCore;

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
		public DbSet<MqttUser> MqttUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Alarm>().ToTable("Alarms").HasIndex(a => a.Id).IsUnique();
			modelBuilder.Entity<AlarmState>().ToTable("AlarmStates").HasIndex(a => a.Id).IsUnique();
			modelBuilder.Entity<ArmedState>().ToTable("ArmedStates").HasIndex(a => a.Id).IsUnique();
			modelBuilder.Entity<CalibratedDistance>().ToTable("CalibratedDistances").HasIndex(d => d.Id).IsUnique();
			modelBuilder.Entity<SilentState>().ToTable("SilentStates").HasIndex(s => s.Id).IsUnique();

			Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MqttUser> mqttUsers = modelBuilder.Entity<MqttUser>().ToTable("MqttUsers");
			mqttUsers.HasIndex(u => u.Id).IsUnique();
			mqttUsers.HasIndex(u => u.ClientId).IsUnique();
			mqttUsers.HasIndex(u => u.Username).IsUnique();
			// Default user
			Utils.Hashing.TryHash("o1to!9BJj8YdgCP!Njp^mD1gY^Jr3Cew", out string password, out string salt);
			mqttUsers.HasData(new MqttUser(1, "AlarmSystem", "AlarmSystem", password, salt));
		}
	}
}
