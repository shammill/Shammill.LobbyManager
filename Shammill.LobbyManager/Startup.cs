using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shammill.LobbyManager.Services;
using Shammill.LobbyManager.Services.Interfaces;
using Shammill.LobbyManager.Hubs;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Configuration;

namespace Shammill.LobbyManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ILobbyService, LobbyService>();
            services.AddScoped<IPlayerService, PlayerService>();

            if (Config.SignalREnabled)
            {
                services.AddScoped<IClientNotifier, ClientNotifier>();
                services.AddSignalR();
            }
            else
            {
                services.AddScoped<IClientNotifier, DisabledClientNotifier>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (Config.SignalREnabled)
            {
                app.UseSignalR(routes =>
                {
                    routes.MapHub<SignalRHub>("/signalr");
                });
            }

            app.UseMvc();
        }
    }
}
