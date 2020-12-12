using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

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
        public static List<string> StringToBin(string inputstring)
        {
            // Creating array of string length  
            char[] ch = new char[inputstring.Length];
            List<string> listOutput = new List<string>();
            // Copy character by character into array  
            for (int i = 0; i < inputstring.Length; i++)
            {
                ch[i] = inputstring[i];
                string input = ch[i].ToString();

                if (input == "A")
                {
                    listOutput.Add("00000");
                }
                else if (input == "B")
                {
                    listOutput.Add("00001");
                }
                else if (input == "C")
                {
                    listOutput.Add("00010");
                }
                else if (input == "D")
                {
                    listOutput.Add("00011");
                }
                else if (input == "E")
                {
                    listOutput.Add("00100");
                }
                else if (input == "F")
                {
                    listOutput.Add("00101");
                }
                else if (input == "G")
                {
                    listOutput.Add("00110");
                }
                else if (input == "H")
                {
                    listOutput.Add("00111");
                }
                else if (input == "I")
                {
                    listOutput.Add("01000");
                }
                else if (input == "J")
                {
                    listOutput.Add("01001");
                }
                else if (input == "K")
                {
                    listOutput.Add("01010");
                }
                else if (input == "L")
                {
                    listOutput.Add("01011");
                }
                else if (input == "M")
                {
                    listOutput.Add("01100");
                }
                else if (input == "N")
                {
                    listOutput.Add("01101");
                }
                else if (input == "O")
                {
                    listOutput.Add("01110");
                }
                else if (input == "P")
                {
                    listOutput.Add("01111");
                }
                else if (input == "Q")
                {
                    listOutput.Add("10000");
                }
                else if (input == "R")
                {
                    listOutput.Add("10001");
                }
                else if (input == "S")
                {
                    listOutput.Add("10010");
                }
                else if (input == "T")
                {
                    listOutput.Add("10011");
                }
                else if (input == "U")
                {
                    listOutput.Add("10100");
                }
                else if (input == "V")
                {
                    listOutput.Add("10101");
                }
                else if (input == "W")
                {
                    listOutput.Add("10110");
                }
                else if (input == "X")
                {
                    listOutput.Add("10111");
                }
                else if (input == "Y")
                {
                    listOutput.Add("11000");
                }
                else if (input == "Z")
                {
                    listOutput.Add("11001");
                }
            }
            return listOutput;
        }
        public static string BinToString(string input)
        {
            input = input.ToUpper();
            if (input == "0")
            {
                return "A";
            }
            else if (input == "1")
            {
                return "B";
            }
            else if (input == "10")
            {
                return "C";
            }
            else if (input == "11")
            {
                return "D";
            }
            else if (input == "100")
            {
                return "E";
            }
            else if (input == "101")
            {
                return "F";
            }
            else if (input == "110")
            {
                return "G";
            }
            else if (input == "111")
            {
                return "H";
            }
            else if (input == "1000")
            {
                return "I";
            }
            else if (input == "1001")
            {
                return "J";
            }
            else if (input == "1010")
            {
                return "K";
            }
            else if (input == "1011")
            {
                return "L";
            }
            else if (input == "1100")
            {
                return "M";
            }
            else if (input == "1101")
            {
                return "N";
            }
            else if (input == "1110")
            {
                return "O";
            }
            else if (input == "1111")
            {
                return "P";
            }
            else if (input == "10000")
            {
                return "Q";
            }
            else if (input == "10001")
            {
                return "R";
            }
            else if (input == "10010")
            {
                return "S";
            }
            else if (input == "10011")
            {
                return "T";
            }
            else if (input == "10100")
            {
                return "U";
            }
            else if (input == "10101")
            {
                return "V";
            }
            else if (input == "10110")
            {
                return "W";
            }
            else if (input == "10111")
            {
                return "X";
            }
            else if (input == "11000")
            {
                return "Y";
            }
            else if (input == "11001")
            {
                return "Z";
            }
            else
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            string p = null;
            string k = null;
            string x = null;
            string y = null;
            string z = null;
            Console.Write("PlanText= ");
            p = Console.ReadLine();
            var list = StringToBin(p.ToUpper());
            k = "10010101001110100110000"; //Tiny A5/1 key

            x = k.Substring(0, 6); //X gồm 6 bit (x0; x1; :::; x5)
            y = k.Substring(6, 8); //Y gồm 8 bit (y0; y1; :::; y7)
            z = k.Substring(14, 9); //Y gồm 8 bit (y0; y1; :::; y7)
            string cyperText = null;
            foreach (var item in list)
            {
                Console.WriteLine(" p= {0}", item);
                string si = null;
                for (int i = 0; i < item.Length; i++)
                {
                    if (k.Length == 23) //Tiny A5/1 key
                    {
                        int X = Int32.Parse(x.Substring(1, 1)), //t tại x
                            Y = Int32.Parse(y.Substring(3, 1)), //t tại y
                            Z = Int32.Parse(z.Substring(3, 1)); //t tại z
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
                            //Quay Y - XOR t
                            int t = Int32.Parse(y.Substring(6, 1))
                                ^ Int32.Parse(y.Substring(7, 1));
                            y = t + y.Substring(0, 7);
                        }
                        if (Z == maj(X, Y, Z))
                        {
                            //Quay Z - XOR t
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
                var cInt = (Convert.ToInt32(item, 2) ^ Convert.ToInt32(si, 2)) % 26;// XOR 2 giá trị plantext và si giá trị Ỉnt
                var c = Convert.ToString(cInt, 2); // Convert về giá trị binary
                Console.WriteLine("si= " + si);
                Console.WriteLine("c= {0} <=> {1}",c, BinToString(c.ToString()));
                Console.WriteLine("---------------");
                cyperText = cyperText + BinToString(c.ToString());
            }
            Console.WriteLine("CyperText= " + cyperText);
            Console.ReadLine();
        }
    }
}
