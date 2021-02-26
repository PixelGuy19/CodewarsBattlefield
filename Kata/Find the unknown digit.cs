using System.Data;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static int solveExpression(string expression)
        {
            string[] Operators = expression.Split('=');

            for (int i = Operators[1].Replace("-", "").StartsWith("?") &&
                         Operators[1].Length > 1 ? 1 : 0; i < 10; i++)
            {
                if (Evaluate(Operators[0].Replace("?", i.ToString()))
                    == Evaluate(Operators[1].Replace("?", i.ToString())))
                {
                    if (expression.Contains(i.ToString()))
                    {
                        continue;
                    }
                    return i;
                }
            }

            return -1; 

            int Evaluate(string exp)
            {
                return (int) new DataTable().Compute(exp, "");
            }
        }
    }
}