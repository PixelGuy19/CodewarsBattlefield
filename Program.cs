using System;
using System.Collections.Generic;

namespace CodeWarsBattlefield
{
    internal partial class Program
    {
        private static readonly IList<int> collection = new List<int>
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};

        private static PagnationHelper<int> helper;

        public static void SetUp()
        {
            helper = new PagnationHelper<int>(collection, 10);
        }

        private static void Main(string[] args)
        {
            SetUp();

            Console.Write(helper.PageIndex(24));
            Console.Read();
        }
    }
}