using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        //I don't solve this Kata too, but solution was too beautiful
        public static List<string> SinglePermutations(string s) => $"{s}".Length < 2 ?
            new List<string> { s } :
            SinglePermutations(s.Substring(1))
                .SelectMany(x => Enumerable.Range(0, x.Length + 1)
                    .Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
                .Distinct()
                .ToList();
    }
}