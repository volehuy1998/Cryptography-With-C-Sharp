using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A51
{
    class Program
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
        static void Main(string[] args)
        {
            string p = null;
            string k = null;
            string x = null;
            string y = null;
            string z = null;
            Console.Write("P= ");
            p = Console.ReadLine();

            k = "10010101001110100110000"; //Tiny A5/1 key
            string si = null;
            x = k.Substring(0, 6);
            y = k.Substring(6, 8);
            z = k.Substring(14, 9);
            for (int i = 0; i < p.Length; i++)
            {
                if (k.Length == 23)
                {
                    Console.WriteLine("Tiny A5/1");
                    int X = Int32.Parse(x.Substring(1, 1)),
                        Y = Int32.Parse(y.Substring(3, 1)),
                        Z = Int32.Parse(z.Substring(3, 1));
                    if (X == maj(X, Y, Z))
                    {
                        //Quay X - XOR t
                        int t = Int32.Parse(x.Substring(2, 1))
                            ^ Int32.Parse(x.Substring(4, 1))
                            ^ Int32.Parse(x.Substring(5, 1));
                        x = t + x.Substring(0, 5);
                    }
                    if (Y == maj(X, Y, Z))
                    {
                        //Quay Y
                        int t = Int32.Parse(y.Substring(6, 1))
                            ^ Int32.Parse(y.Substring(7, 1));
                        y = t + y.Substring(0, 7);
                    }
                    if (Z == maj(X, Y, Z))
                    {
                        //Quay Z
                        int t = Int32.Parse(z.Substring(2, 1))
                            ^ Int32.Parse(z.Substring(7, 1))
                            ^ Int32.Parse(z.Substring(8, 1));
                        z = t + z.Substring(0, 8);
                    }
                    int temp = (Int32.Parse(x.Substring(5, 1))
                        ^ Int32.Parse(y.Substring(7, 1))
                        ^ Int32.Parse(z.Substring(8, 1)));
                    si = si + temp;
                }
            }
            Console.WriteLine("s= "+ si);
            Console.WriteLine("c= "+ (Int64.Parse(p) ^ Int64.Parse(si)));
            Console.ReadLine();
        }
    }
}
