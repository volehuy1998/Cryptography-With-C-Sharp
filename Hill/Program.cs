﻿using Common;
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
        private static readonly string key = "RRFVSVCCT";

        private static Matrix<double> GenerateKey(string key)
        {
            int size = (int)Math.Sqrt(key.Length);
            Matrix<double> matrixKey = Matrix<double>.Build.Dense(size, size);
            List<string> keyBlocks = SplitStringToMultiBlock(key, size);

            for (int i = 0; i < size; i++)
            {
                List<double[]> subKeyRow = ConvertStringToBlocks(keyBlocks[i]);
                Matrix<double> subMatrixKey = Matrix<double>.Build.DenseOfRows(subKeyRow.ToArray());
                matrixKey.SetRow(i, Vector<double>.Build.DenseOfArray(subMatrixKey.ToRowMajorArray()));
            }

            return matrixKey;
        }

        private static Matrix<double> AdjK(Matrix<double> key)
        {
            Matrix<double> matrixAdjK = Matrix<double>.Build.Dense(key.RowCount, key.ColumnCount);

            for (int i = 0; i < key.RowCount; i++)
            {
                for (int j = 0; j < key.ColumnCount; j++)
                {
                    Matrix<double> subMatrix = key.RemoveRow(i);
                    subMatrix = subMatrix.RemoveColumn(j);
                    double det = subMatrix.Determinant();
                    matrixAdjK[i, j] = Math.Pow(-1.0, i) * Math.Pow(-1.0, j) * Math.Round(det, 2, MidpointRounding.AwayFromZero);
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

        private static List<string> SplitStringToMultiBlock(string str, int blockSize)
        {
            List<string> blocks = new List<string>();

            for (int i = 0; i < str.Length; i += blockSize)
                blocks.Add(str.Substring(i, Math.Min(blockSize, str.Length - i)));

            return blocks;
        }

        private static List<double[]> ConvertStringToBlocks(string str)
        {
            List<double[]> subBlocks = new List<double[]>();

            for (int i = 0; i < str.Length; i++)
            {
                char p = char.ToUpper(str[i]);
                int alphabetIndex = Defines.ALPHABET.IndexOf(p);
                subBlocks.Add(new double[] { alphabetIndex });
            }

            return subBlocks;
        }

        private static string PaddingMatchWithBlockSize(string str, int blockSize)
        {
            string modifedString = str + new string(' ', (blockSize - (str.Length % blockSize)) % blockSize);
            return modifedString;
        }

        private static string Encrypt(string message, Matrix<double> key)
        {
            string cipher = string.Empty;
            int blockSize = key.ColumnCount;
            message = PaddingMatchWithBlockSize(message, blockSize);
            Matrix<double> matrixC = Matrix<double>.Build.Dense(message.Length / key.ColumnCount, blockSize);
            List<string> blockMessages = SplitStringToMultiBlock(message, blockSize);

            for (int i = 0; i < blockMessages.Count; i++)
            {
                Matrix<double> subMatrixC = null;
                Matrix<double> subMatrixP = null;
                List<double[]> subBlockMessage = ConvertStringToBlocks(blockMessages[i]);

                subMatrixP = Matrix<double>.Build.DenseOfRows(subBlockMessage.ToArray());
                subMatrixC = key.Multiply(subMatrixP).Modulus(Defines.ALPHABET.Length);
                matrixC.SetRow(i, Vector<double>.Build.DenseOfArray(subMatrixC.ToColumnMajorArray()));
            }

            cipher = ConvertMatrixToString(matrixC);

            return cipher;
        }

        private static string Decrypt(string cipher, Matrix<double> key)
        {
            string msg = string.Empty;
            int blockSize = key.ColumnCount;
            cipher = PaddingMatchWithBlockSize(cipher, blockSize);
            int detK = (int)key.Determinant();
            BigInteger detInverseK = MathHelpers.Modulo(BigInteger.Pow(detK, MathHelpers.EulerTotient(Defines.ALPHABET.Length) - 1), Defines.ALPHABET.Length);
            Matrix<double> matrixP = Matrix<double>.Build.Dense(cipher.Length / key.ColumnCount, blockSize);
            Matrix<double> matrixInverseK = AdjK(key).Modulus(Defines.ALPHABET.Length).Multiply((double)detInverseK).Modulus(Defines.ALPHABET.Length);
            List<string> blockCiphers = SplitStringToMultiBlock(cipher, blockSize);

            for (int i = 0; i < blockCiphers.Count; i++)
            {
                Matrix<double> subMatrixP = null;
                Matrix<double> subMatrixC = null;
                List<double[]> subBlockCipher = ConvertStringToBlocks(blockCiphers[i]);

                subMatrixC = Matrix<double>.Build.DenseOfRowArrays(subBlockCipher.ToArray());
                subMatrixP = matrixInverseK.Multiply(subMatrixC).Modulus(Defines.ALPHABET.Length);
                matrixP.SetRow(i, Vector<double>.Build.DenseOfArray(subMatrixP.ToColumnMajorArray()));
            }

            msg = ConvertMatrixToString(matrixP);

            return msg;
        }

        static void Main(string[] args)
        {
            Matrix<double> matrixKey = GenerateKey(key);
            string cipher = Encrypt(message, matrixKey);
            string msg = Decrypt(cipher, matrixKey);
        }
    }
}
