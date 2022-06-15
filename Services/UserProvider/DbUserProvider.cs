using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.UserProvider
{
    using DAL.Entities;
    using DAL.Repositories;

    internal class DbUserProvider : IUserProvider
    {
        #region Properties

        private UsersRepository usersRepository;

        #endregion

        #region Constructors

        public DbUserProvider(UsersRepository usersRepository) => this.usersRepository = usersRepository;

        #endregion

        #region Methods

        public Users GetUserById(uint id) => usersRepository.GetUsers().Find(user => user.Id == id);

        public Users GetUserByEmail(string email) => usersRepository.GetUsers().Find(user => user.UserEmail == email);

        public List<Users> GetUsers() => usersRepository.GetUsers();

        #endregion
    }
}
