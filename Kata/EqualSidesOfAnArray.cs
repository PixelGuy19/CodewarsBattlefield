using System;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        //Find equal sides of array
        public static int FindEvenIndex(params int[] Arr)
        {
            if (Arr.Sum() == 0)
            {
                return 0;
            }

            for (int i = 0; i < Arr.Length; i++)
            {
                if (IsSidesEqual(i))
                {
                    return i;
                }
            }

            return -1;

            bool IsSidesEqual(int Index)
            {
                int[] FirstPart = SubArray<int>(Arr, 0, Index);
                int[] SecondPart = SubArray<int>(Arr, Index + 1, Arr.Length - Index - 1);

                return FirstPart.Sum() == SecondPart.Sum();

                //https://stackoverflow.com/questions/943635/how-do-i-clone-a-range-of-array-elements-to-a-new-array
                T[] SubArray<T>(T[] array, int offset, int length)
                {
                    T[] result = new T[length];
                    Array.Copy(array, offset, result, 0, length);
                    return result;
                }
            }
        }
    }
}