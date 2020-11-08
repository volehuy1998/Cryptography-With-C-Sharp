using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MathHelpers
    {
        public static int Modulo(int a, int b)
        {
            return (a % b + b) % b;
        }

        public static Matrix<double> Modulo(Matrix<double> a, int b)
        {
            var matrix = Matrix<double>.Build.Dense(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
            {
                for (int j = 0; j < a.ColumnCount; j++)
                {
                    matrix[i, j] = Modulo((int)a[i, j], b);
                }
            }

            return matrix;
        }
    }
}
