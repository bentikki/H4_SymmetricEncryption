using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    interface IEncryption
    {
        string Name { get; }
        byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv);
        byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv);
    }
}
