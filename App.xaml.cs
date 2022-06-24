﻿using MVVMShop.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMShop.Common.Hashers;
using MVVMShop.DAL;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.DB.DbContexts;
using MVVMShop.HostBuilders;
using MVVMShop.Services;
using MVVMShop.Services.Auth;
using MVVMShop.Services.OrderCreators;
using MVVMShop.Services.ProductCreators;
using MVVMShop.Services.ProductProviders;
using MVVMShop.Services.ProductEditor;
using MVVMShop.Services.ProductRemover;
using MVVMShop.Services.UserProvider;
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
                .ConfigureAppConfiguration(app => { app.AddJsonFile("appsettings.json"); })
                .ConfigureServices((hostContext, services) =>
                {
                    string connectionString = hostContext.Configuration.GetConnectionString("Default");

                    services.AddSingleton(new MVVMShopContextFactory(connectionString));
                    services.AddSingleton<DbConnection>();
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<AuthStore>();
                    services.AddSingleton<ProductsStore>();
                    services.AddSingleton<UsersStore>();

                    services.AddSingleton(s =>
                        new BaseRepository<Users>(s.GetRequiredService<DbConnection>(), "users"));
                    services.AddSingleton(s =>
                        new BaseRepository<Products>(s.GetRequiredService<DbConnection>(), "products"));
                    services.AddSingleton(s =>
                        new BaseRepository<Orders>(s.GetRequiredService<DbConnection>(), "orders"));
                    services.AddSingleton(s =>
                        new BaseRepository<OrderIncludesProducts>(s.GetRequiredService<DbConnection>(),
                            "order_includes_products"));


                    services.AddSingleton<IAuthService>(s =>
                        new DbAuthService(s.GetRequiredService<MVVMShopContextFactory>(), new DefaultPasswordHasher()));
                    services.AddSingleton<IProductCreator, DbProductCreator>();
                    services.AddSingleton<IProductProvider, DbProductProvider>();
                    services.AddSingleton<IProductEditor, DbProductEditor>();
                    services.AddSingleton<IProductRemover, DbProductRemover>();
                    services.AddSingleton<IOrderCreator, DbOrderCreator>();
                    services.AddSingleton<IUserProvider, DbUserProvider>();

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

            MVVMShopContextFactory mvvmShopContextFactory = _host.Services.GetRequiredService<MVVMShopContextFactory>();
            using MVVMShopContext dbContext = mvvmShopContextFactory.CreateDbContext();
            dbContext.Database.Migrate();

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