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
            hostBuilder
                .AddViewModel<MainViewModel>()
                .AddViewModel<StartPageViewModel>()
                .AddViewModel<LoginPageViewModel>()
                .AddViewModel<RegisterPageViewModel>()
                .AddViewModel<CustomerPageViewModel>()
                .AddViewModel<AssistantPageViewModel>()
                .AddViewModel<AdminPageViewModel>()
                .AddViewModel<UserManagementViewModel>()
                .AddViewModel<CartPageViewModel>()
                .AddViewModel<FinalizationPageViewModel>()
                .AddViewModel<HistoryPageViewModel>();

            return hostBuilder;
        }
    }
}