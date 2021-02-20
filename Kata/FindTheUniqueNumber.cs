using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            int[] Members = numbers.Distinct().ToArray();
            return numbers.ToList().FindAll(P => P == Members[0])
                .Count > 1 ? Members[1] : Members[0];
        }
        
        //Best p. => return numbers.GroupBy(x=>x).Single(x=> x.Count() == 1).Key;
    }
}