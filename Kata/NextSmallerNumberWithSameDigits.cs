using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static long NextSmaller(long n)
        {
            //I failed this Kata too. What the bad day..
            //I think solution in character permutation and comparison with original.
            
            string Digits = n.ToString();

            for (long i = n - 1; i >= 0; i--)
            {
                if (new System.Collections.Generic.HashSet<char>(Digits).SetEquals(i.ToString()))
                {
                    if (i.ToString().StartsWith('0'))
                    {
                        return 0;
                    }
                    return i;
                }
            }

            return -1;
        }
    }
}