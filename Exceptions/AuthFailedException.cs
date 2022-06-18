using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Exceptions
{
    internal class AuthFailedException : Exception
    {
        public AuthFailedException()
        {
        }

        public AuthFailedException(string message) : base(message)
        {
        }

        public AuthFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}