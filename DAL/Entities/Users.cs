using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Entities
{
    #region Roles

    public enum UserRole
    {
        Klient,
        Pracownik,
        Admin
    }

    #endregion

    public sealed class Users : BaseEntity, IDatabaseReader<Users>
    {
        #region Properties

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }

        #endregion

        #region Constructors

        public Users() { }

        public Users(string userEmail, string userPassword, string firstName, string lastName, UserRole role)
        {
            Id = null;
            UserEmail = userEmail.Trim();
            UserPassword = userPassword.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Role = role;
        }

        public Users(Users user)
        {
            Id = user.Id;
            UserEmail = user.UserEmail;
            UserPassword = user.UserPassword;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
        }

        #endregion

        #region Methods

        public Users ReadDataFromDatabase(MySqlDataReader reader) => new Users
        {
            Id = uint.Parse(reader["id"].ToString()),
            UserEmail = reader["user_email"].ToString(),
            UserPassword = reader["user_password"].ToString(),
            FirstName = reader["first_name"].ToString(),
            LastName = reader["last_name"].ToString(),
            Role = (UserRole)Enum.Parse(typeof(UserRole), reader["user_role"].ToString())
        };

        public string Insert() => $"(0, {UserEmail}, {UserPassword}, {FirstName}, {LastName}, {Role})";

        public override string ToString() => $"{FirstName} {LastName}, {UserEmail}, {Role}";

        public override bool Equals(object obj)
        {
            var user = obj as Users;

            if (user is null)
                return false;

            if (UserEmail.ToLower() != user.UserEmail.ToLower())
                return false;

            if (UserPassword.ToLower() != user.UserPassword.ToLower())
                return false;

            if (FirstName.ToLower() != user.FirstName.ToLower())
                return false;

            if (LastName.ToLower() != user.LastName.ToLower())
                return false;

            if (Role != user.Role)
                return false;

            return true;
        }

        public override int GetHashCode() => base.GetHashCode();

        #endregion
    }
}