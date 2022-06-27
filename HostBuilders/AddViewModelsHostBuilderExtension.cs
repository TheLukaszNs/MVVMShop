using Microsoft.Extensions.Hosting;
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