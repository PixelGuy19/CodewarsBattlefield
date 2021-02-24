using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static List<string> Top3(string s)
        {
            //It works but in random test of Kata was too match issues
            
            s = s.ToLower();
            string[] Words;
               Regex Reg = new Regex("\\b[a-z']+");
                   Words = Reg.Matches(s).Select(m => m.Value).ToArray();

            Dictionary<string, int> WordsScore = new Dictionary<string, int>();
            foreach (string Word in Words)
            {
                if (!WordsScore.TryGetValue(Word, out int Count))
                {
                    WordsScore.Add(Word, s.IndexOfAny(Word.ToCharArray()));
                }
            }
            WordsScore.Remove("'");

            if (WordsScore.Count == 0)
            {
                return new List<string>();
            }
            var OutKeys = WordsScore.ToList();
            
            OutKeys.Sort((Pair1, Pair2) =>
            {
                int Compare = Pair1.Value.CompareTo(Pair2.Value);
                if (Compare == 0)
                {
                    Compare = -String.Compare(Pair1.Key, Pair2.Key, StringComparison.CurrentCulture);
                }
                return Compare;
            });
            List<string> Out = OutKeys.Select(S => S.Key).ToArray().Reverse().Take(3).ToList();

            foreach (KeyValuePair<string,int> Pair in OutKeys)
            {
                Console.WriteLine($"{Pair.Key}->{Pair.Value}");
            }
            string[] Difentitions = new[] {"x", "y", "z"};
            for (int Index = 0; Index < Out.Count; Index++)
            {
                string OutStr = Out[Index];
                s = s.Replace(OutStr, $"<{Difentitions[Index]}>");
            }
            Console.WriteLine(s);

            return Out;
        }
    }//https://www.codewars.com/kata/51e056fe544cf36c410000fb/train/csharp
}