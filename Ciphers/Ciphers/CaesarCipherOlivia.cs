using System;
using Ciphers.Interfaces;

namespace Ciphers.Ciphers
{
    public class CaesarCipherOlivia: ICipher
    {

        #region Constructors and Properties

        int shift = 0;

        public CaesarCipherOlivia()
        {
        }

        #endregion

        #region User Interface

        public string Run(string[] args)
        {
            bool encoding = DetermineEncodeOrDecode();
            shift = DetermineShift();
            string value = DetermineValue(encoding);

            Console.WriteLine(string.Empty);
            Console.WriteLine("You are " + (encoding ? "encoding" : "decoding") + " the string '" + value + "' using a Caesar Cipher with shift " + shift.ToString());

            if (encoding)
            {
                 return Encode(value);
            }
            else
            {
                return Decode(value);
            }
        }

        private bool DetermineEncodeOrDecode(bool retry = false)
        {
            if (!retry)
            {
                Console.WriteLine("Are you encoding or decoding a secret message? (E/D)");
            }
            string val = Console.ReadLine();

            if (val.ToLower() != "e" && val.ToLower() != "d")
            {
                Console.WriteLine("Sorry, I didn't understand that - please just enter 'E' for encode or 'D' for decode");
                return DetermineEncodeOrDecode(true);
            }

            return val.ToLower() == "e";
        }

        private int DetermineShift(bool retry = false)
        {
            if (!retry)
            {
                Console.WriteLine("Enter the Caesar Cipher shift:");
            }
            string val = Console.ReadLine();

            if (!int.TryParse(val, out int offset))
            {
                Console.WriteLine("Sorry, I didn't understand that - please just enter a number for the shift:");
                return DetermineShift(true);
            }

            return offset;
        }

        private string DetermineValue(bool encoding)
        {
            if (encoding)
            {
                Console.WriteLine("Enter the text you want to encode:");
            }
            else
            {
                Console.WriteLine("Enter the text you want to decode:");
            }

            string val = Console.ReadLine();

            return val;
        }

        #endregion

        #region Encoding and Decoding Functions

        public string Decode(string encodedValue)
        {
            string output = string.Empty;

            var buffer = encodedValue.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                // Check if this is a letter - only decode letters
                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
                {
                    bool capitalLetter = letter >= 'A' && letter <= 'Z';

                    // UN-Shift our letter
                    letter = (char)(letter - shift);

                    // If we've gone past the end of the alphabet, loop back to the beginning
                    if (capitalLetter && letter < 'A')
                    {
                        letter = (char)(letter + 26);
                    }
                    if (!capitalLetter && letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                }

                // Add my letter to the output
                output += letter.ToString();
            }


            return output;
        }

        public string Encode(string plainTextValue)
        {
            string output = string.Empty;

            var buffer = plainTextValue.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                // Check if this is a letter - only encode letters
                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
                {
                    bool capitalLetter = letter >= 'A' && letter <= 'Z';

                    // Shift our letter
                    letter = (char)(letter + shift);

                    // If we've gone past the end of the alphabet, loop back to the beginning
                    if (capitalLetter && letter > 'Z')
                    {
                        letter = (char)(letter - 26);
                    }
                    if (!capitalLetter && letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                }

                // Add my letter to the output
                output += letter.ToString();
            }


            return output;
        }

        #endregion
    }
}
