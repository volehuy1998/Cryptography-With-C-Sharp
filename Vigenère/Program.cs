using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Vigenère
{
    class Program
    {
        private static readonly string message = "meet me after the toga party";
        private static readonly string key = "ZPBYJRSKFLXQNWVDHMGUTOIAEC";

        private static string Encrypt(string message, string key)
        {
            string cipher = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char p = char.ToUpper(message[i]);
                int alphabetIndex = Defines.ALPHABET.IndexOf(p);
                if (alphabetIndex >= 0)
                {
                    cipher += key[alphabetIndex];
                }
                else
                {
                    cipher += p;
                }
            }

            return cipher;
        }

        private static string Decrypt(string cipher, string key)
        {
            string msg = string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                char p = char.ToUpper(cipher[i]);
                int cipherIndex = key.IndexOf(p);
                if (cipherIndex >= 0)
                {
                    msg += Defines.ALPHABET[cipherIndex];
                }
                else
                {
                    msg += p;
                }
            }

            return msg;
        }

        static void Main(string[] args)
        {
            string cipher = Encrypt(message, key);
            string msg = Decrypt(cipher, key);
        }
    }
}
