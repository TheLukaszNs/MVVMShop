using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Services.UserProvider
{
    public interface IUserProvider
    {
        Users GetUserById(uint id);
        Users GetUserByEmail(string email);
        List<Users> GetUsers();
    }
}