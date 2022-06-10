using MVVMShop.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVMShop.Services;
using MVVMShop.View;
using MVVMShop.ViewModel;

namespace MVVMShop
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateStartPageViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private RegisterPageViewModel CreateRegisterPageViewModel()
        {
            return new RegisterPageViewModel(new NavigationService(_navigationStore, CreateLoginPageViewModel));
        }

        private LoginPageViewModel CreateLoginPageViewModel() => new LoginPageViewModel();

        private StartPageViewModel CreateStartPageViewModel()
        {
            return new StartPageViewModel(
                new NavigationService(_navigationStore, CreateRegisterPageViewModel),
                new NavigationService(_navigationStore, CreateLoginPageViewModel));
        } 
    }
}
