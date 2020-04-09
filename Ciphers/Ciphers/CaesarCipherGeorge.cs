using System;
using Ciphers.Interfaces;

namespace Ciphers.Ciphers
{
    public class CaesarCipherGeorge: ICipher
    {

        #region Constructors and Properties

        int shift = 0;

        public CaesarCipherGeorge()
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
            // Convert the string of text into an array
            char[] buffer = encodedValue.ToCharArray();

            // Loop through each letter in the array
            for (int i = 0; i < buffer.Length; i++)
            {
                // Get the letter we want to decode
                char letter = buffer[i];

                // If this is a letter (A-Z or a-z) then we will decode it - ignore numbers, spaces etc
                if ((letter >= 65 && letter <= 90) || (letter >= 97 && letter <= 122))
                {
                    bool capitalLetter = letter <= 90;

                    // Remove shift because we are decoding
                    letter = (char)(letter - shift);

                    // Add 26 on underflow.
                    // Subtract 26 on overflow.
                    if (capitalLetter)
                    {
                        if (letter < 'A')
                        {
                            letter = (char)(letter + 26);
                        }
                        else if (letter > 'Z')
                        {
                            letter = (char)(letter - 26);
                        }
                    }
                    else
                    {
                        if (letter < 'a')
                        {
                            letter = (char)(letter + 26);
                        }
                        else if (letter > 'z')
                        {
                            letter = (char)(letter - 26);
                        }
                    }

                    // Update the result in the array
                    buffer[i] = letter;
                }
            }

            // Convert the array of letters into a string
            return new string(buffer);
        }

        public string Encode(string plainTextValue)
        {
            // Convert the string of text into an array
            char[] buffer = plainTextValue.ToCharArray();

            // Loop through each letter in the array
            for (int i = 0; i < buffer.Length; i++)
            {
                // Get the letter we want to encode
                char letter = buffer[i];

                // If this is a letter (A-Z or a-z) then we will encode it - ignore numbers, spaces etc
                if ((letter >= 65 && letter <= 90) || (letter >= 97 && letter <= 122))
                {
                    bool capitalLetter = letter <= 90;

                    // Add shift because we are encoding
                    letter = (char)(letter + shift);

                    // Subtract 26 on overflow.
                    // Add 26 on underflow.
                    if (capitalLetter)
                    {
                        if (letter > 'Z')
                        {
                            letter = (char)(letter - 26);
                        }
                        else if (letter < 'A')
                        {
                            letter = (char)(letter + 26);
                        }
                    }
                    else
                    {
                        if (letter > 'z')
                        {
                            letter = (char)(letter - 26);
                        }
                        else if (letter < 'a')
                        {
                            letter = (char)(letter + 26);
                        }
                    }

                    // Update the result in the array
                    buffer[i] = letter;
                }
            }

            // Convert the array of letters into a string
            return new string(buffer);
        }

        #endregion
    }
}
