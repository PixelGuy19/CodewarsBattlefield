using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static List<string> BalancedParens(int n)
        {
            string In = string.Empty;
            for (int i = 0; i < n; i++)
            {
                In += "()";
            }

            List<string> Out = new List<string>();
            foreach (string Permutation in SinglePermutations(In))
            {
                if (IsValidReview(Permutation))
                {
                    Out.Add(Permutation);
                }
            }
            
            return Out;

            bool IsValidReview(string s)
            {
                Stack<char> endings = new Stack<char>();

                foreach (var curr in s)
                {
                    switch (curr)
                    {
                        case '(':
                            endings.Push(')');
                            break;
                        case '[':
                            endings.Push(']');
                            break;
                        case '{':
                            endings.Push('}');
                            break;
                        case ')':
                        case ']':
                        case '}':
                            if (endings.Count == 0 || endings.Pop() != curr)
                                return false;
                            break;

                    }
                }

                return endings.Count == 0;
            }
        }
    }
}