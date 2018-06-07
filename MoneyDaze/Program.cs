using Blazored.Storage;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using MoneyDaze.Services;
using MoneyDaze.Services.Contracts;

namespace MoneyDaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddLocalStorage();
                configure.AddSingleton<IBudgetService, BudgetService>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
