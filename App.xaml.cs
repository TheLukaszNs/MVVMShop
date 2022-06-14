using MVVMShop.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMShop.DAL;
using MVVMShop.HostBuilders;
using MVVMShop.Services;
using MVVMShop.Services.Auth;
using MVVMShop.View;
using MVVMShop.ViewModel;

namespace MVVMShop
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<DbConnection>();
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<AuthStore>();

                    services.AddSingleton<IAuthService>(s =>
                        new DbAuthService(s.GetRequiredService<AuthStore>(), s.GetRequiredService<DbConnection>()));

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var navigationService =
                _host.Services.GetRequiredService<NavigationService<StartPageViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow?.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}