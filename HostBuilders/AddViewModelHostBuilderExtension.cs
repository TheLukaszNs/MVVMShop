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
    public static class AddViewModelHostBuilderExtension
    {
        public static IHostBuilder AddViewModel<T>(this IHostBuilder hostBuilder) where T : BaseVM
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient<T>();
                services.AddSingleton<Func<T>>(s => s.GetRequiredService<T>);
                services.AddSingleton<NavigationService<T>>();
            });

            return hostBuilder;
        }
    }
}