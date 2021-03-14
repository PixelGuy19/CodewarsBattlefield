using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static IEnumerable<int> Stream()
        {
            //I think top coders use some tricks of math theory
            //best p.
            
            
            List<int> FirstPrimeNumbers = new List<int>
                {2, 3, 5, 7};
            for (int i = 100; i <= 100000;)
            {
                Console.WriteLine(i);
                FirstPrimeNumbers.AddRange(GetPrimeNumbersInRange(i));
                i = i * 10;
            }

            return FirstPrimeNumbers;

            List<int> GetPrimeNumbersInRange(int Range)
            {
                List<int> RangeInts = Enumerable.Range(FirstPrimeNumbers.Max() + 1, Range).ToList();
                foreach (int I in FirstPrimeNumbers)
                {
                    RangeInts = RangeInts.Where(N => N % I != 0).ToList();
                }

                return RangeInts;
            }
        }
    }
}