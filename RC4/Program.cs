﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4
{
    class Program
    {
        static int[] CreateTinyRC4(int[] K)
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
        static int[] GenerateTinyRC4(int[] S)
        {
            int i = 0, j = 0;
            while (true)
            {
                i = (i + 1) % 8;
                j = (j + S[i]) % 8;
                //swap
                int temp = 0;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
                int t = (S[i] + S[j]) % 8;
                int k = S[t];
            }
        }
        static void Main(string[] args)
        {
           int[] K = { 2, 1, 3};
            string output = string.Join(".", CreateTinyRC4(K));
            Console.WriteLine(output);
        }
    }
}