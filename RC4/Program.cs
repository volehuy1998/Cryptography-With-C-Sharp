using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4
{
    public class Program
    {
        //Giai đoạn khởi tạo
        public static int[] CreateTinyRC4(int[] K)
        {
            int[] S = new int[8];
            int[] T = new int[8];
            for (int i = 0; i < 8; i++)
            {
                S[i] = i;
                T[i] = K[i % K.Length];
            }
            //Hoan vi
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = (j + S[i] + T[i]) % 8;
                //swap
                int temp = 0;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }
             return S;
        }
        //Giai đoạn sinh số
        public static List<string> GenerateTinyRC4(int[] S, string[] P)
        {
            int i = 0, j = 0, count = 0;
            List<string> s = new List<string>();
            while (count < P.Length)
            {
                count++;
                i = (i + 1) % 8;
                j = (j + S[i]) % 8;
                //swap
                int temp = 0;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
                int t = (S[i] + S[j]) % 8;
                int k = S[t];
                string bin = Convert.ToString(k, 2);
                int length = bin.Length;
                for (int loop = length; loop < P[0].Length; loop++)
                {
                    bin = 0 + bin;
                }
                s.Add(bin);
                Console.WriteLine(k);
                Console.WriteLine(string.Join(".", S));
            }
            return s;
        }
        static void Main(string[] args)
        {
           int[] K = { 2, 1, 3};
            string output = string.Join(".", CreateTinyRC4(K));
            string[] P = { "001", "000","110"};
            string output2 = string.Join(".", GenerateTinyRC4(CreateTinyRC4(K),P));
            Console.WriteLine(output);
            Console.WriteLine(output2);
        }
    }
}
