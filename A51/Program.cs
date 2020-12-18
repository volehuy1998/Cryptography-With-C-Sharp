﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace A51
{
    public class Program
    {
        private static int maj(int x, int y, int z)
        {
            if (x+y+z >= 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static string A51(int loop ,string input)
        {
            int[] x = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            int[] y = { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 };
            int[] z = { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 };

            StringBuilder result = new StringBuilder();
            StringBuilder keybit = new StringBuilder();
            for (int i = 0; i < loop; i++)
            {
                //tính giá trị maj
                int X = x[8], 
                    Y = y[10],
                    Z = z[10];
                if (X == maj(X, Y, Z))
                {
                    //Quay X - XOR t
                    int t = x[13] ^ x[16] ^ x[17] ^ x[18];
                    for (int j = x.Length - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            x[j] = t;
                        }
                        else
                        {
                            x[j] = x[j - 1];
                        }

                    }
                }
                Console.Write("X: ");
                for (int j = 0; j < x.Length; j++)
                {
                    Console.Write(x[j]);
                }

                if (Y == maj(X, Y, Z))
                {
                    //Quay Y - XOR t
                    int t = y[20] ^ y[21];
                    for (int j = y.Length - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            y[j] = t;
                        }
                        else
                        {
                            y[j] = y[j - 1];
                        }
                    }
                }

                Console.Write("\nY: ");
                for (int j = 0; j < y.Length; j++)
                {
                    Console.Write(y[j]);
                }

                if (Z == maj(X, Y, Z))
                {
                    //Quay Z - XOR t
                    int t = z[7] ^ z[20] ^ z[21] ^ z[22];
                    for (int j = z.Length - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            z[j] = t;
                        }
                        else
                        {
                            z[j] = z[j - 1];
                        }
                    }
                }

                Console.Write("\nZ: ");
                for (int j = 0; j < z.Length; j++)
                {
                    Console.Write(z[j]);
                }

                //Bit sinh ra
                int key = x[18] ^ y[21] ^ z[22];
                Console.Write("\nKeystream bit = {0} ^ {1} ^ {2} = {3}", x[19 - 1], y[22 - 1], z[23 - 1], key);
                Console.WriteLine("\n");
                keybit.Append(key);
            }
            Console.WriteLine("Keystream: {0}", keybit);
            int k = Convert.ToInt32(keybit.ToString(), 2);
            Console.WriteLine("Keystream(Int): {0}", k);

            for (int i = 0; i < input.Length; i++)
            {
                result.Append((char)(input[i] ^ (k % 256)));
            }
            return result.ToString();
        }

        public static void Main(string[] args)
        {
            string input = null;
            Console.Write("Input: ", input);
            input = Console.ReadLine();
            string encrypt = A51(18, input);
            Console.WriteLine("Encryption Text: {0}", encrypt);
            Console.Write("....Press Enter key to Decrypt...");
            Console.ReadLine();
            string decrypt = A51(18, encrypt);
            Console.WriteLine("Decryption Text: {0}", decrypt);
            Console.ReadLine();
        }
    }
}
