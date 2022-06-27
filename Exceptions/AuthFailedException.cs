using System;

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