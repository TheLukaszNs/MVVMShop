using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Common.Hashers
{
    public interface IHasher
    {
        string Hash(string value, byte[] salt = null);
        bool Equals(string value, string newValue);
    }
}