using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Services.UserCreator
{
    public interface IUserCreator
    {
        bool CreateUser(Users user);
    }
}