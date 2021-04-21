using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion.Helpers
{
    /// <summary>
    /// Key generator.
    /// Can be used in order to get truly random values.
    /// </summary>
    class KeyGenerator : IKeyGenerator
    {
        public byte[] GenerateKey(int keySize)
        {
            // Uses RNGCryptoServiceProvider instead of fx. Random, to create more random and secure values.
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[keySize];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
