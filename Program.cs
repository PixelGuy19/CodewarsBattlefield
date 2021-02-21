using System;
using System.Collections.Generic;

namespace CodeWarsBattlefield
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" }));
            Console.Read();
        }
    }
}