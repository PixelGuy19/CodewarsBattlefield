using System;
using System.Linq;
using System.Numerics;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static BigInteger CountOnes(long left, long right)
        {
            int Out = 0;
            for (long i = left; i <= right; i++)
            {
                Out += Convert.ToString(i, 2).Count(s => s == '1');
            }

            return Out;
        }
    }
}