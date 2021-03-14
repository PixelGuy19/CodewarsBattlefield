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

            List<int> Numbers = Stream().ToList();
            string Txt = string.Join(',', Numbers[1337]);
            Console.WriteLine(Txt);
            Console.Read();
        }
    }
}