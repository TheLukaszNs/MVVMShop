using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MVVMShop.Common.Hashers
{
    public class DefaultPasswordHasher : IHasher
    {
        public string Hash(string value, byte[] salt = null)
        {
            if (salt is not { Length: 16 })
            {
                salt = new byte[16];

                using var rngCsp = RandomNumberGenerator.Create();

                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 16
            ));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        public bool Equals(string storedPassword, string password)
        {
            var saltAndHash1 = storedPassword.Split(':');

            if (saltAndHash1.Length != 2)
                return false;

            var salt = Convert.FromBase64String(saltAndHash1[0]);

            var hashOfSecondValue = Hash(password, salt)
                .Split(':')[1];

            return string.Equals(saltAndHash1[1], hashOfSecondValue);
        }
    }
}