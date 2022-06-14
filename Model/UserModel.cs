using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Model
{
    using DAL.Entities;

    internal sealed class UserModel
    {
        #region Properties

        public ObservableCollection<Users> _Users { get; set; } = new ObservableCollection<Users>();

        #endregion

        #region Constructors

        public UserModel()
        {
            
        }

        #endregion
    }
}
