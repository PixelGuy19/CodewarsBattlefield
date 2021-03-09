using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> dependencies)
        {
            Dictionary<string, string[]> Correct = new Dictionary<string, string[]>();
            foreach (KeyValuePair<string, string[]> Dependency in dependencies)
            {
                Correct.Add(Dependency.Key, GetDependencies(dependencies[Dependency.Key]).ToArray());
            }

            return Correct;

            List<string> GetDependencies(string[] Content, List<string> Out = null)
            {
                if (Content.Length == 0)
                {
                    return new List<string>();
                }

                Out = new List<string>();
                foreach (string S in Content)
                {
                    if (Out.Contains(S))
                    {
                        continue;
                    }
                    Out.Add(S);
                    Out.AddRange(GetDependencies(dependencies[S], Out));
                }

                return Out.Distinct().ToList();
            }
        }
    }
}