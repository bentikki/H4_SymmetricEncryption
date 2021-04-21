using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            IBenchmarkTimer timer = new BenchmarkStopWatch();
            string menuSelection = string.Empty;
            int keySize = 0;
            int IVSize = 0;

            do
            {
                Console.Clear();
                Console.Write("Input to encrypt: ");
                string plaintTextInput = Console.ReadLine();


                Console.WriteLine("Hashing menu:");
                Console.WriteLine("1. DES");
                Console.WriteLine("2. Triple DES");
                Console.WriteLine("3. AES");

                IEncryption encrypter = null;
                byte[] encryptedValue = null;
                menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        // Different keysizes are available to diffrent Encryption methods.
                        keySize = 8;
                        IVSize = 8;
                        encrypter = new DESEncrypter();
                        break;
                    case "2":
                        keySize = 24;
                        IVSize = 8;
                        encrypter = new TripleDESEncrypter();
                        break;
                    case "3":
                        keySize = 32;
                        IVSize = 16;
                        encrypter = new AESEncrypter();
                        break;
                    default:
                        break;
                }

                
                byte[] generatedKey = KeyGenerator.GenerateKey(keySize);
                byte[] generatedIV = KeyGenerator.GenerateKey(IVSize);

                Console.WriteLine("Generated Key    : " + Convert.ToBase64String(generatedKey));
                Console.WriteLine("Generated IV    : " + Convert.ToBase64String(generatedIV));
                Console.WriteLine();

                timer.Start();
                encryptedValue = encrypter.Encrypt(Encoding.UTF8.GetBytes(plaintTextInput), generatedKey, generatedIV);
                timer.Stop();
                Console.Write($"{encrypter.Name} encryption: ");
                Console.Write(Convert.ToBase64String(encryptedValue));
                Console.WriteLine();
                Console.Write($"Benchmark: " + timer.TimingResult());
                timer.Reset();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any key to Decrypt:");
                Console.ReadKey();
                Console.WriteLine("Encrypted Value   : " + Convert.ToBase64String(encryptedValue));
                timer.Start();
                Console.WriteLine("Decrypted Value   : " + Encoding.UTF8.GetString(encrypter.Decrypt(encryptedValue, generatedKey, generatedIV)));
                timer.Stop();
                Console.WriteLine($"Benchmark        : " + timer.TimingResult());
                timer.Reset();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            } while (true);

            
        }
    }
}
