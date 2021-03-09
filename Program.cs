using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var startFiles = new Dictionary<string, string[]>();
            // ex 1
            // startFiles["A"] = new string[] {"B", "D"};
            // startFiles["B"] = new string[] {"C"};
            // startFiles["C"] = new string[] {"D"};
            // startFiles["D"] = new string[] {};
            
            startFiles["A"] = new string[] {"B"};
            startFiles["B"] = new string[] {"C"};
            startFiles["C"] = new string[] {"D"};
            startFiles["D"] = new string[] {"A"};

            
            Console.WriteLine(new Program().Evaluate("2^3+2^(2/2)"));
            Console.Read();
        }
    }
}