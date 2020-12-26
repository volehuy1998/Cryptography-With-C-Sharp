using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int choose = 0;
            Console.WriteLine("----------Menu------------");
            Console.WriteLine("1. Mã hóa chuỗi bằng RC4.");
            Console.WriteLine("2. Mã hóa âm thanh bằng RC4.");
            Console.Write("Nhập lựa chọn của bạn: ");
            Int32.TryParse(Console.ReadLine(), out choose);

            switch (choose)
            {
                case 1:
                    Console.Write("Nhập từ bản phím chuỗi cần mã hóa RC4: ");
                    string inputString = Console.ReadLine();
                    string encrypt = RC4(inputString, "19981006");
                    Console.WriteLine("Chuỗi sau khi được mã hóa: {0}", encrypt);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã chuỗi trên...");
                    Console.ReadLine();
                    string decrypt = RC4(encrypt, "19981006");
                    Console.WriteLine("Chuỗi sau khi được giải mã: {0}", decrypt);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nhập tên file cần mã hóa RC4: ");
                    string input = Console.ReadLine();
                    byte[] bytes = File.ReadAllBytes(input);
                    byte[] encryptFile = RC4InputFile(bytes, "19981006");
                    Console.WriteLine("File đã được mã hóa: En-{0}", input);
                    string filenameEncrypt = "En-" + input;
                    File.WriteAllBytes(filenameEncrypt, encryptFile);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã chuỗi trên...");
                    Console.ReadLine();
                    byte[] decryptFile = RC4InputFile(encryptFile, "19981006");
                    string filenameDecrypt = "De-" + input;
                    Console.WriteLine("File đã được giải mã: De-{0}", input);
                    File.WriteAllBytes(filenameDecrypt, decryptFile);
                    Console.ReadLine();
                    break;
            }

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
        public static byte[] RC4InputFile(byte[] input, string key)
        {
            List<byte> result = new List<byte>();
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

                result.Add((byte)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToArray();
        }

    }
}
