using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Model
{
    using DAL.Entities;
    using DAL.Repositories;

    internal sealed class UserModel
    {
        #region Properties

        private UsersRepository usersRepository;
        public ObservableCollection<Users> _Users { get; set; } = new ObservableCollection<Users>();

        #endregion

        #region Constructors

        public UserModel(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
            List<Users> users = usersRepository.GetUsers();

            foreach (Users user in users)
                _Users.Add(user);
        }

        #endregion

        #region Methods

        public bool Include(Users user) => _Users.Contains(user);

        public Users FindUser(uint id)
        {
            foreach(Users user in _Users)
                if (user.Id == id)
                    return user;
            return null;
        }

        public Users FindUser(string email)
        {
            foreach (Users user in _Users)
                if (user.UserEmail == email)
                    return user;
            return null;
        }

        public bool AddUser(Users user)
        {
            if (!Include(user))
            {
                _Users.Add(user);
                return true;
            }

            return false;
        }

        public bool EditUser(Users user, uint id)
        {
            if (usersRepository.EditUser(user, id))
            {
                for (int i = 0; i < _Users.Count; i++)
                {
                    if (_Users[i].Id == id)
                    {
                        _Users[i] = new Users(user);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool DeleteUser(uint id)
        {
            if (usersRepository.DeleteUser(id))
            {
                foreach (Users user in _Users)
                {
                    if (user.Id == id)
                    {
                        _Users.Remove(user);
                        return true;
                    }
                }
            }

            return false;   
        }

        #endregion
    }
}
