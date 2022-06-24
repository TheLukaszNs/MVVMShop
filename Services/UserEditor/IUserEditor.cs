using System;
using MVVMShop.Model;

namespace MVVMShop.Services.UserEditor;

public interface IUserEditor
{
    User EditUser(Guid id, User newUser);
}