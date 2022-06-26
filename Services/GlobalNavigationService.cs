using MVVMShop.ViewModel;

namespace MVVMShop.Services;

public class GlobalNavigationService
{
    public NavigationService<StartPageViewModel> StartPageNavigationService { get; }
    public NavigationService<LoginPageViewModel> LoginPageNavigationService { get; }
    public NavigationService<RegisterPageViewModel> RegisterPageNavigationService { get; }
    public NavigationService<AdminPageViewModel> AdminPageNavigationService { get; }
    public NavigationService<UserManagementViewModel> UserManagementNavigationService { get; }
    public NavigationService<CartPageViewModel> CartPageNavigationService { get; }
    public NavigationService<AssistantPageViewModel> AssistantPageNavigationService { get; }
    public NavigationService<CustomerPageViewModel> CustomerPageNavigationService { get; }

    public GlobalNavigationService(NavigationService<StartPageViewModel> startPageNavigationService,
        NavigationService<LoginPageViewModel> loginPageNavigationService,
        NavigationService<RegisterPageViewModel> registerPageNavigationService,
        NavigationService<AdminPageViewModel> adminPageNavigationService,
        NavigationService<UserManagementViewModel> userManagementNavigationService,
        NavigationService<CartPageViewModel> cartPageNavigationService,
        NavigationService<AssistantPageViewModel> assistantPageNavigationService,
        NavigationService<CustomerPageViewModel> customerPageNavigationService)
    {
        StartPageNavigationService = startPageNavigationService;
        LoginPageNavigationService = loginPageNavigationService;
        RegisterPageNavigationService = registerPageNavigationService;
        AdminPageNavigationService = adminPageNavigationService;
        UserManagementNavigationService = userManagementNavigationService;
        CartPageNavigationService = cartPageNavigationService;
        AssistantPageNavigationService = assistantPageNavigationService;
        CustomerPageNavigationService = customerPageNavigationService;
    }
}