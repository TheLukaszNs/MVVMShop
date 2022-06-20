using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Model
{
    public class User
    {
        public uint? Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public uint Points { get; set; }

        public User(uint? id, string email, string firstName, string lastName, UserRole role, uint points)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Points = points;
        }

        public User(Users user)
        {
            Id = user.Id;
            Email = user.UserEmail;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Points = user.Points;
        }
    }
}