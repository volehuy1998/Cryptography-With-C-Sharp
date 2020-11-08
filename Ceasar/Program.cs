﻿namespace Ceasar
{
    class Program
    {
        private static int key = 3;
        private static readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string message = "meet me after the toga party";

        private static int Modulo(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Encrypt(string message)
        {
            string cipher = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char p = char.ToUpper(message[i]);
                int alphaIndex = alphabet.IndexOf(p);
                if (alphaIndex >= 0)
                {
                    // c = (p + k) mod 26
                    cipher += alphabet[Modulo(alphaIndex + key, alphabet.Length)];
                }
                else
                {
                    cipher += p;
                }
            }

            return cipher;
        }

        private static string Decrypt(string cipher)
        {
            string msg = string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                char p = char.ToUpper(cipher[i]);
                int cipherIndex = alphabet.IndexOf(p);
                if (cipherIndex >= 0)
                {
                    // p = (c - k) mod 26
                    msg += alphabet[Modulo(cipherIndex - key, alphabet.Length)];
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
            string cipher = Encrypt(message);
            string msg = Decrypt(cipher);
        }
    }
}
