using Common;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hill
{
    class Program
    {
        private static readonly string message = "paymoremoney";
        private static readonly Matrix<double> matrixK = Matrix<double>.Build.DenseOfRows(new double[][]
        {
            new double[] { 17, 17, 05 },
            new double[] { 21, 18, 21 },
            new double[] { 02, 02, 19 },
        });
        private static readonly int ONLY_ONE_ELEMENT = 1;
        private static readonly int FIRST_ELEMENT = 0;

        public static Matrix<double> Modulo(Matrix<double> a, int b)
        {
            var matrix = Matrix<double>.Build.Dense(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
            {
                for (int j = 0; j < a.ColumnCount; j++)
                {
                    matrix[i, j] = MathHelpers.Modulo((int)a[i, j], b);
                }
            }

            return matrix;
        }

        private static string Encrypt(string message, Matrix<double> key)
        {
            string cipher = string.Empty;
            int blockSize = key.ColumnCount;
            List<string> blockMessages = new List<string>();

            for (int i = 0; i < message.Length; i += blockSize)
                blockMessages.Add(message.Substring(i, Math.Min(blockSize, message.Length - i)));

            for (int i = 0; i < blockMessages.Count; i++)
            {
                double[,] ps = null;
                Matrix<double> matrixC = null;
                Matrix<double> matrixP = null;
                Matrix<double> matrixKxP = null;
                List<double[]> matrixBlockMessage = new List<double[]>();

                for (int j = 0; j < blockMessages[i].Length; j++)
                {
                    char p = char.ToUpper(blockMessages[i][j]);
                    int alphabetIndex = Defines.ALPHABET.IndexOf(p);
                    matrixBlockMessage.Add(new double[ONLY_ONE_ELEMENT]);
                    if (alphabetIndex >= 0)
                    {
                        matrixBlockMessage[j].SetValue(alphabetIndex, FIRST_ELEMENT);
                    }
                }

                matrixP = Matrix<double>.Build.DenseOfRows(matrixBlockMessage.ToArray());
                matrixKxP = matrixK.Multiply(matrixP);
                matrixC = Modulo(matrixKxP, Defines.ALPHABET.Length);

                ps = matrixC.Storage.ToArray();
                for (int k = 0; k < ps.Length; k++)
                {
                    cipher += Defines.ALPHABET[(int)ps[k, FIRST_ELEMENT]];
                }
            }

            return cipher;
        }

        static void Main(string[] args)
        {
            string cipher = Encrypt(message, matrixK);
        }
    }
}
