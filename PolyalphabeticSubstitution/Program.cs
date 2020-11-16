using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace PolyalphabeticSubstitution
{
    class Program
    {
        private static readonly string message = "WeAreDiscoveredSaveYourSelf";
        private static readonly string wordKey = "DECEPTIVE";

        private static string GenerateKey(string wordKey, int size)
        {
            string key = string.Empty;

            for (int i = 0; i < size; i++)
            {
                key += wordKey[i % wordKey.Length];
            }

            return key;
        }

        private static string Encrypt(string message, string key)
        {
            string cipher = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char p = char.ToUpper(message[i]);
                int msgColumnIndex = p - 'A';
                int keyRowIndex = key[i] - 'A';
                cipher += Defines.POLY_ALPHABETIC_SUBSTITUTION_TABLE[keyRowIndex][msgColumnIndex];
            }

            return cipher;
        }

        private static string Decrypt(string cipher, string key)
        {
            string msg = string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                char p = char.ToUpper(cipher[i]);
                int keyRowIndex = key[i] - 'A';
                msg += Defines.ALPHABET[Array.IndexOf(Defines.POLY_ALPHABETIC_SUBSTITUTION_TABLE[keyRowIndex], p)];
            }

            return msg;
        }

        static void Main(string[] args)
        {
            string key = GenerateKey(wordKey, message.Length);
            string cipher = Encrypt(message, key);
            string msg = Decrypt(cipher, key);
        }
    }
}
