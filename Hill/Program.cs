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

        private static Matrix<double> AdjK(Matrix<double> key)
        {
            Matrix<double> matrixAdjK = Matrix<double>.Build.Dense(key.RowCount, key.ColumnCount);

            for (int i = 0; i < key.RowCount; i++)
            {
                for (int j = 0; j < key.ColumnCount; j++)
                {
                    Matrix<double> subMatrix = key.RemoveRow(i);
                    subMatrix = subMatrix.RemoveColumn(j);
                    matrixAdjK[i, j] = Math.Pow(-1.0, i) * Math.Pow(-1.0, j) * (int)subMatrix.Determinant();
                }
            }

            matrixAdjK = matrixAdjK.Transpose();

            return matrixAdjK;
        }

        private static string ConvertMatrixToString(Matrix<double> matrix)
        {
            string result = string.Empty;

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    result += Defines.ALPHABET[(int)matrix[i, j]];
                }
            }

            return result;
        }

        private static string Encrypt(string message, Matrix<double> key)
        {
            string cipher = string.Empty;
            int blockSize = key.ColumnCount;
            Matrix<double> matrixC = Matrix<double>.Build.Dense(message.Length / key.ColumnCount, blockSize);
            List<string> blockMessages = new List<string>();

            for (int i = 0; i < message.Length; i += blockSize)
                blockMessages.Add(message.Substring(i, Math.Min(blockSize, message.Length - i)));

            for (int i = 0; i < blockMessages.Count; i++)
            {
                Matrix<double> subMatrixC = null;
                Matrix<double> subMatrixP = null;
                List<double[]> matrixBlockMessage = new List<double[]>();

                for (int j = 0; j < blockMessages[i].Length; j++)
                {
                    char p = char.ToUpper(blockMessages[i][j]);
                    int alphabetIndex = Defines.ALPHABET.IndexOf(p);
                    matrixBlockMessage.Add(new double[] { alphabetIndex });
                }

                subMatrixP = Matrix<double>.Build.DenseOfRows(matrixBlockMessage.ToArray());
                subMatrixC = matrixK.Multiply(subMatrixP).Modulus(Defines.ALPHABET.Length);
                matrixC.SetRow(i, Vector<double>.Build.DenseOfArray(subMatrixC.ToColumnMajorArray()));
            }

            cipher = ConvertMatrixToString(matrixC);

            return cipher;
        }

        private static string Decrypt(string cipher, Matrix<double> key)
        {
            string msg = string.Empty;
            int blockSize = key.ColumnCount;
            int detK = (int)matrixK.Determinant();
            BigInteger detInverseK = MathHelpers.Modulo(BigInteger.Pow(detK, MathHelpers.EulerTotient(Defines.ALPHABET.Length) - 1), Defines.ALPHABET.Length);
            Matrix<double> matrixP = Matrix<double>.Build.Dense(cipher.Length / key.ColumnCount, blockSize);
            Matrix<double> matrixInverseK = AdjK(matrixK).Multiply((double)detInverseK).Modulus(Defines.ALPHABET.Length);
            List<string> blockCiphers = new List<string>();

            for (int i = 0; i < cipher.Length; i += blockSize)
                blockCiphers.Add(cipher.Substring(i, Math.Min(blockSize, cipher.Length - i)));

            for (int i = 0; i < blockCiphers.Count; i++)
            {
                Matrix<double> subMatrixP = null;
                Matrix<double> subMatrixC = null;
                List<double[]> subMatrixBlockCipher = new List<double[]>();

                for (int j = 0; j < blockCiphers[i].Length; j++)
                {
                    char p = char.ToUpper(blockCiphers[i][j]);
                    int alphabetIndex = Defines.ALPHABET.IndexOf(p);
                    subMatrixBlockCipher.Add(new double[] { alphabetIndex });
                }

                subMatrixC = Matrix<double>.Build.DenseOfRowArrays(subMatrixBlockCipher.ToArray());
                subMatrixP = matrixInverseK.Multiply(subMatrixC).Modulus(Defines.ALPHABET.Length);
                matrixP.SetRow(i, Vector<double>.Build.DenseOfArray(subMatrixP.ToColumnMajorArray()));
            }

            for (int i = 0; i < matrixP.RowCount; i++)
            {
                for (int j = 0; j < matrixP.ColumnCount; j++)
                {
                    msg += Defines.ALPHABET[(int)matrixP[i, j]];
                }
            }

            return msg;
        }

        static void Main(string[] args)
        {
            string cipher = Encrypt(message, matrixK);
            string msg = Decrypt(cipher, matrixK);
        }
    }
}
