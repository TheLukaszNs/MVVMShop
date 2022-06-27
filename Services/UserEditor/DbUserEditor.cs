using System;
using System.Linq;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.UserEditor;

public class DbUserEditor : IUserEditor
{
    private readonly MVVMShopContextFactory _dbContextFactory;

    public DbUserEditor(MVVMShopContextFactory dbContextFactory) => _dbContextFactory = dbContextFactory;

    public User EditUser(Guid id, User newUser)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var user = context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return null;

        user.Email = newUser.Email;
        user.FirstName = newUser.FirstName;
        user.LastName = newUser.LastName;
        user.Role = newUser.Role;
        context.SaveChanges();

        return ToUser(user);
    }

    private User ToUser(UserDTO user) => new()
    {
        Id = user.Id,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Role = user.Role,
        Points = user.Points,
    };
}