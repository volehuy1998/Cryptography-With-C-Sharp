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
    }
}
