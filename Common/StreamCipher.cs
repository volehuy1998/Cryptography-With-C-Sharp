using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class StreamCipher
    {
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
                else if (input == "!")
                {
                    listOutput.Add("11010");
                }
                else if (input == "@")
                {
                    listOutput.Add("11011");
                }
                else if (input == "#")
                {
                    listOutput.Add("11100");
                }
                else if (input == "$")
                {
                    listOutput.Add("11101");
                }
                else if (input == "%")
                {
                    listOutput.Add("11110");
                }
                else if (input == "^")
                {
                    listOutput.Add("11111");
                }
            }
            return listOutput;
        }
        public static string IntToString(int input)
        {
            if (input == 0)
            {
                return "A";
            }
            else if (input == 1)
            {
                return "B";
            }
            else if (input == 2)
            {
                return "C";
            }
            else if (input == 3)
            {
                return "D";
            }
            else if (input == 4)
            {
                return "E";
            }
            else if (input == 5)
            {
                return "F";
            }
            else if (input == 6)
            {
                return "G";
            }
            else if (input == 7)
            {
                return "H";
            }
            else if (input == 8)
            {
                return "I";
            }
            else if (input == 9)
            {
                return "J";
            }
            else if (input == 10)
            {
                return "K";
            }
            else if (input == 11)
            {
                return "L";
            }
            else if (input == 12)
            {
                return "M";
            }
            else if (input == 13)
            {
                return "N";
            }
            else if (input == 14)
            {
                return "O";
            }
            else if (input == 15)
            {
                return "P";
            }
            else if (input == 16)
            {
                return "Q";
            }
            else if (input == 17)
            {
                return "R";
            }
            else if (input == 18)
            {
                return "S";
            }
            else if (input == 19)
            {
                return "T";
            }
            else if (input == 20)
            {
                return "U";
            }
            else if (input == 21)
            {
                return "V";
            }
            else if (input == 22)
            {
                return "W";
            }
            else if (input == 23)
            {
                return "X";
            }
            else if (input == 24)
            {
                return "Y";
            }
            else if (input == 25)
            {
                return "Z";
            }
            else if (input == 26)
            {
                return "!";
            }
            else if (input == 27)
            {
                return "@";
            }
            else if (input == 28)
            {
                return "#";
            }
            else if (input == 29)
            {
                return "$";
            }
            else if (input == 30)
            {
                return "%";
            }
            else if (input == 31)
            {
                return "^";
            }
            else
            {
                return null;
            }
        }
    }
}
