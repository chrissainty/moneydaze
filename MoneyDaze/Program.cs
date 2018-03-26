using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using MoneyDaze.Services;
using MoneyDaze.Services.Contracts;
using System;

namespace MoneyDaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddSingleton<IBudgetService, BudgetService>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
