using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static int ParseInt(string s)
        {
            if (s == "zero")
            {
                return 0;
            }
            
            Dictionary<string, int> SimpleNumbers = GetFirstHundred();

            if (SimpleNumbers.TryGetValue(s, out int Number))
            {
                return Number;
            }
            
            s = s.Replace(" and ", " ");
            
            List<string> Parts = s.Split(' ').ToList();
            List<int> IntParts = new int[Parts.Count].ToList();
            for (int I = 0; I < Parts.Count; I++)
            {
                string Part = Parts[I];
                IntParts[I] = SimpleNumbers[Part];
            }

            for (int i = 100; i <= IntParts.Max(); i *= 10)
            {
                while (IntParts.FindAll(m => m == i).Count > 0 && IntParts.Count != 1)
                {
                    int DifficultPartIndex = IntParts.FindIndex(p => p == i);
                    IntParts[DifficultPartIndex] *= DifficultPartIndex - 1 >= 0 ?
                        IntParts[DifficultPartIndex - 1] : 1;

                    if (DifficultPartIndex + 1 < IntParts.Count)
                    {
                        if (IntParts[DifficultPartIndex + 1] % 10 != 0 ||
                            IntParts[DifficultPartIndex + 1] < i)
                        {
                            IntParts[DifficultPartIndex] += IntParts[DifficultPartIndex + 1];
                            IntParts.RemoveAt(DifficultPartIndex + 1);
                        }
                    }

                    if (DifficultPartIndex - 1 >= 0)
                    {
                        IntParts.RemoveAt(DifficultPartIndex - 1);
                    }
                }
            }

            return IntParts.First();

            Dictionary<string, int> GetFirstHundred()
            {
                Dictionary<string, int> Out = new Dictionary<string, int>()
                {
                    {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"five", 5},
                    {"six", 6},
                    {"seven", 7},
                    {"eight", 8},
                    {"nine", 9},
                    {"ten", 10},
                    {"eleven", 11},
                    {"twelve", 12},
                    {"thirteen", 13},
                    {"fourteen", 14},
                    {"fifteen", 15},
                    {"sixteen", 16},
                    {"seventeen", 17},
                    {"eighteen", 18},
                    {"nineteen", 19},
                    {"twenty", 20},
                    {"thirty", 30},
                    {"forty", 40},
                    {"fifty", 50},
                    {"sixty", 60},
                    {"seventy", 70},
                    {"eighty", 80},
                    {"ninety", 90},
                    {"hundred", 100},
                    {"thousand", 1000},
                    {"million", 1000000}
                };

                var RevercedOut = Out.GroupBy(p => p.Value)
                    .ToDictionary(g => g.Key, g
                        => g.Select(pp => pp.Key).ToList().First());

                for (int i2 = 0; i2 < 8; i2++)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        Out.Add($"{RevercedOut[20 + i2 * 10]}-{RevercedOut[i]}", 20 + i2 * 10 + i);
                    }
                }

                return Out;
            }
        }
    }
}