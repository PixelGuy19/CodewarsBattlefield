using System;
using System.Data;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        //Also, it is solution for "My BEDMAS Approved Calculator" Kata
        public double Evaluate(string expression)
        {
            return Math.Round(Convert.ToDouble(new DataTable().Compute(expression, "")), 6, 
                MidpointRounding.AwayFromZero);
        }
    }
}