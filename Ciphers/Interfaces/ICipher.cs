using System;
namespace Ciphers.Interfaces
{
    public interface ICipher
    {
        string Run(string[] args);
        string Encode(string plainTextValue);
        string Decode(string encodedValue);
    }
}
