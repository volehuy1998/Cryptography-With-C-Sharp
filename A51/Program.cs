using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private static byte[] A51InputFile(int loop, byte[] input)
        {
            int[] x = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            int[] y = { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 };
            int[] z = { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 };

            List<byte> result = new List<byte>();
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
                result.Add((byte)(input[i] ^ (k % 256)));
            }
            return result.ToArray();
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
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int choose = 0;
            Console.WriteLine("----------Menu------------");
            Console.WriteLine("1. Mã hóa chuỗi bằng A5/1.");
            Console.WriteLine("2. Mã hóa file bằng A5/1.");
            Console.WriteLine("3. Mã hóa chuỗi bằng RC4.");
            Console.WriteLine("4. Mã hóa file bằng RC4.");
            Console.Write("Nhập lựa chọn của bạn: ");
            Int32.TryParse(Console.ReadLine(),out choose);

            Random rnd = new Random();
            int loop = rnd.Next(1, 20);
            loop = 10;
            Stopwatch stopWatch = new Stopwatch();
            switch (choose)
            {
                case 1:
                    string input = null;
                    Console.Write("Nhập từ bản phím chuỗi cần mã hóa A5/1: ", input);
                    input = Console.ReadLine();
                    string encrypt = A51(loop, input);
                    Console.WriteLine("Chuỗi sau khi được mã hóa: {0}", encrypt);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã chuỗi trên...");
                    Console.ReadLine();
                    string decrypt = A51(loop, encrypt);
                    Console.WriteLine("Chuỗi sau khi được giải mã: {0}", decrypt);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nhập tên file cần mã hóa A5/1: ");
                    input = Console.ReadLine();
                    byte[] bytes = File.ReadAllBytes("File/" + input);
                    stopWatch.Start();
                    byte[] encryptFile = A51InputFile(loop, bytes);
                    stopWatch.Stop();
                    Console.WriteLine("{0}ms", stopWatch.ElapsedMilliseconds);
                    stopWatch.Reset();
                    Console.WriteLine("File đã được mã hóa: En-A51-{0}", input);
                    string filenameEncrypt = "File/En-A51-"+input;
                    File.WriteAllBytes(filenameEncrypt, encryptFile);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã âm thanh trên...");
                    Console.ReadLine();
                    stopWatch.Start();
                    byte[] decryptFile = A51InputFile(loop, encryptFile);
                    stopWatch.Stop();
                    Console.WriteLine("{0}ms", stopWatch.ElapsedMilliseconds);
                    stopWatch.Reset();
                    string filenameDecrypt = "File/De-A51-" + input;
                    Console.WriteLine("File đã được giải mã: De-A51-{0}", input);
                    File.WriteAllBytes(filenameDecrypt, decryptFile);
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Nhập từ bản phím chuỗi cần mã hóa RC4: ");
                    string inputString = Console.ReadLine();
                    encrypt = RC4(inputString, "0dd62c1565299b226e12816b19f38ff68c2ff10c0d3f9c5978cda5274acbcf2f");
                    Console.WriteLine("Chuỗi sau khi được mã hóa: {0}", encrypt);
                    //bên gửi
                    //Chuyển bản mã đã được mã hóa sang byte[] để thực hiển base64encode
                    var a = Encoding.UTF32.GetBytes(encrypt);
                    // chuyển sang chuỗi base64
                    var base64encode = Convert.ToBase64String(a);
                    // bên nhận
                    // thực hiện decode
                    var base64decode = Convert.FromBase64String(base64encode);
                    // Lấy được chuỗi byte[] bên gửi convert sang string để thực hiện giải mã
                    var b = Encoding.UTF32.GetString(base64decode);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã chuỗi trên...");
                    Console.ReadLine();
                    decrypt = RC4(encrypt, "0dd62c1565299b226e12816b19f38ff68c2ff10c0d3f9c5978cda5274acbcf2f");
                    Console.WriteLine("Chuỗi sau khi được giải mã: {0}", decrypt);
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Nhập tên file cần mã hóa RC4: ");
                    input = Console.ReadLine();
                    bytes = File.ReadAllBytes("File/" + input);
                    stopWatch.Start();
                    encryptFile = RC4InputFile(bytes, "19981006");
                    stopWatch.Stop();
                    Console.WriteLine("{0}ms", stopWatch.ElapsedMilliseconds);
                    stopWatch.Reset();
                    Console.WriteLine("File đã được mã hóa: En-RC4-{0}", input);
                    filenameEncrypt = "File/En-RC4-" + input;
                    File.WriteAllBytes(filenameEncrypt, encryptFile);
                    Console.Write("....Nhấn Enter để tiếp tục giải mã chuỗi trên...");
                    Console.ReadLine();
                    stopWatch.Start();
                    decryptFile = RC4InputFile(encryptFile, "19981006");
                    stopWatch.Stop();
                    Console.WriteLine("{0}ms", stopWatch.ElapsedMilliseconds);
                    stopWatch.Reset();
                    filenameDecrypt = "File/De-RC4-" + input;
                    Console.WriteLine("File đã được giải mã: De-RC4-{0}", input);
                    File.WriteAllBytes(filenameDecrypt, decryptFile);
                    Console.ReadLine();
                    break;
            }

        }
    }
}
