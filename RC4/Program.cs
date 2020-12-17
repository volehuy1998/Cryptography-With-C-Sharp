using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputString = "aibietgidau";
            string encrypt = RC4(inputString, "19981006");
            string decrypt = RC4(encrypt, "19981006");
            Console.WriteLine(encrypt);
            Console.WriteLine(decrypt);
        }

        public static string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] box = new int[256];

            for (int i = 0; i < 256; i++)
            {
                box[i] = i;
            }

            for (int i = 0; i < 256; i++)
            {
                j = (key[i % key.Length] + box[i] + j) % 256;
                x = box[i];
                box[i] = box[j];
                box[j] = x;
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = i % 256;
                j = (box[y] + j) % 256;
                x = box[y];
                box[y] = box[j];
                box[j] = x;

                result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToString();
        }
    }
}
