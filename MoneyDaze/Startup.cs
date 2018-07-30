using Blazored.Storage;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyDaze;
using MoneyDaze.Services;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalStorage();
        services.AddSingleton<AppState>();
    }

    public void Configure(IBlazorApplicationBuilder app)
    {
        app.AddComponent<App>("app");
    }
}