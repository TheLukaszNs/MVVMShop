using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Stores
{
    public class AuthStore
    {
        private bool _isAuthenticated;

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                _isAuthenticated = value;
                OnAuthStateChanged();
            }
        }

        public event Action<bool> AuthStateChanged;

        private void OnAuthStateChanged()
        {
            AuthStateChanged?.Invoke(_isAuthenticated);
        }
    }
}