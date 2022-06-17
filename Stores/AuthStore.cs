using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.Stores
{
    public class AuthStore
    {
        private User _authenticatedUser;

        public User AuthenticatedUser
        {
            get => _authenticatedUser;
            set
            {
                _authenticatedUser = value;
                OnAuthStateChanged();
            }
        }

        public bool IsAuthenticated => _authenticatedUser != null;

        public event Action<User> AuthStateChanged;

        private void OnAuthStateChanged()
        {
            AuthStateChanged?.Invoke(AuthenticatedUser);
        }
    }
}