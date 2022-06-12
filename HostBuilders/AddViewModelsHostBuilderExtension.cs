using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMShop.Services;
using MVVMShop.ViewModel;

namespace MVVMShop.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient<StartPageViewModel>();
                services.AddSingleton<Func<StartPageViewModel>>(s => s.GetRequiredService<StartPageViewModel>);
                services.AddSingleton<NavigationService<StartPageViewModel>>();

                services.AddTransient<LoginPageViewModel>();
                services.AddSingleton<Func<LoginPageViewModel>>(s => s.GetRequiredService<LoginPageViewModel>);
                services.AddSingleton<NavigationService<LoginPageViewModel>>();

                services.AddTransient<RegisterPageViewModel>();
                services.AddSingleton<Func<RegisterPageViewModel>>(s => s.GetRequiredService<RegisterPageViewModel>);
                services.AddSingleton<NavigationService<RegisterPageViewModel>>();


                services.AddSingleton<MainViewModel>();
            });

            return hostBuilder;
        }
    }
}
