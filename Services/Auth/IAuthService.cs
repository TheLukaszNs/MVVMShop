using MVVMShop.Common.HelperTypes;
using MVVMShop.Model;

namespace MVVMShop.Services.Auth
{
    public interface IAuthService
    {
        User LogIn(string email, string password);
        void Register(UserRegisterData userData);
        void LogOut();
    }
}