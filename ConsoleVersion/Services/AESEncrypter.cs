using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class AESEncrypter : IEncryption
    {
        private string name = "AES";
        public string Name { get { return this.name; } }

        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var cipher = new AesCryptoServiceProvider())
            {
                cipher.Mode = CipherMode.CBC; //Chose the Cipher MODE. Sat to CBC Cipher Block Chaining - to avoid possible dublicate values in the same encryption.
                cipher.Padding = PaddingMode.PKCS7; // Choose paddingmode - Sat, as standard, to PKCS7

                cipher.Key = key;
                cipher.IV = iv; // AES has to have an IV with a bit lenght of 16.

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, cipher.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock(); // Flushing to clear variables from memory.

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var cipher = new AesCryptoServiceProvider())
            {
                cipher.Mode = CipherMode.CBC;
                cipher.Padding = PaddingMode.PKCS7;

                cipher.Key = key;
                cipher.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, cipher.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    var decryptBytes = memoryStream.ToArray();

                    return decryptBytes;
                }
            }
        }


    }
}
