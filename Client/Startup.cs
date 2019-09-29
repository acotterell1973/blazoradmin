using BlazorAdmin.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAdmin.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            System.Diagnostics.Debug.Print("running on the client.... ConfigureServicez");
            services.AddScoped<AuthenticationStateProvider, AdminAuthenticationStateProvider>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            System.Diagnostics.Debug.Print("running on the client... configure");
            app.AddComponent<App>("app");
        }
    }
}
