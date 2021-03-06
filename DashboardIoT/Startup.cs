using DashboardIoT.Data;
using DashboardIoT.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.Extensions;

namespace DashboardIoT
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Settings.Initiate(configuration);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddMqttTcpServerAdapter();
			services.AddConnections();
			services.AddMvc().AddNewtonsoftJson();

			services.AddSingleton<MqttService>();
			services.AddHostedMqttServerWithServices(options => {
				MqttService s = options.ServiceProvider.GetRequiredService<MqttService>();
				s.ConfigureMqttServerOptions(options);
			});

			services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDBContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();

				// If production build, run migrations to keep database up-to-date.
				using (IServiceScope scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
				{
					scope.ServiceProvider.GetRequiredService<Data.ApplicationDBContext>().Database.Migrate();
				}
			}
			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapMqtt("/mqtt");
			});

			app.UseMqttServer(server => app.ApplicationServices.GetRequiredService<MqttService>().ConfigureMqttServer(server));
		}
	}
}
