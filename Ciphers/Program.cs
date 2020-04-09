using System;
using Ciphers.Ciphers;
using Ciphers.Interfaces;

namespace Ciphers
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCipher(args);
        }

        static void RunCipher(string[] args)
        {
            ICipher cipher = new CaesarCipherGeorge();
            string output = cipher.Run(args);

            Console.WriteLine(string.Empty);
            Console.WriteLine("output:");
            Console.WriteLine(output);

            if (DetermineRunAgain())
            {
                RunCipher(args);
            }
        }

        static bool DetermineRunAgain(bool retry = false)
        {
            if (!retry)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Would you like to run again? (Y/N)");
            }
            string val = Console.ReadLine();

            if (val.ToLower() != "y" && val.ToLower() != "n")
            {
                Console.WriteLine("Sorry, I didn't understand that, please enter Y for Yes and N for No");
                return DetermineRunAgain(true);
            }

            return val.ToLower() == "y";
        }
    }
}
