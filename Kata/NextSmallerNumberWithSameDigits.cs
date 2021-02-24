using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static long NextSmaller(long n)
        {
            List<long> AllVariantsLongs = SinglePermutations(n.ToString())
                .ConvertAll(long.Parse).ToList();
            AllVariantsLongs.Sort();
            if (AllVariantsLongs.Count == 0)
            {
                return -1;
            }

            for (int i = AllVariantsLongs.Count - 2; i >= 0; i--)
            {
                if (new HashSet<char>(n.ToString()).SetEquals(AllVariantsLongs[i].ToString()))
                {
                    if (AllVariantsLongs[i] < n)
                    {
                        return AllVariantsLongs[i];
                    }
                }   
            }
            
            return -1;
            
            List<string> SinglePermutations(string s) => $"{s}".Length < 2
                ? new List<string> {s}
                : SinglePermutations(s.Substring(1))
                    .SelectMany(x => Enumerable.Range(0, x.Length + 1)
                        .Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
                    .Distinct()
                    .ToList();
        }
    }
}