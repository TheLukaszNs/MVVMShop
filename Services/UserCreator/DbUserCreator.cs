using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.UserCreator
{
    using DAL.Entities;
    using DAL.Repositories;

    internal class DbUserCreator : IUserCreator
    {
        #region Properties

        private UsersRepository usersRepository;

        #endregion

        #region Constructors

        public DbUserCreator(UsersRepository usersRepository) => this.usersRepository = usersRepository;

        #endregion

        #region Methods

        public bool CreateUser(Users user) => usersRepository.AddUser(user);

        #endregion
    }
}
