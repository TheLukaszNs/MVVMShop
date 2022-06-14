using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.Auth
{
    public interface IAuthService
    {
        bool LogIn(string email, string password);
        bool Register();
        void LogOut();
    }
}