using System;
using System.Data;
namespace CodeWarsBattlefield
{
    partial class Program
    {
        public double Evaluate(string expression)
        {
            return Math.Round(Convert.ToDouble(new DataTable().Compute(expression, "")), 6, 
                MidpointRounding.AwayFromZero);
        }
    }
}