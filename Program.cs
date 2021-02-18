using System;

namespace CodeWarsBattlefield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CreatePhoneNumber(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 9}));
            Console.Read();
        }
        
        //Create phone number
        public static string CreatePhoneNumber(int[] numbers)
        {
            if (numbers.Length != 10)
            {
                return string.Empty;
            }
            
            return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", numbers[0], numbers[1], numbers[2], numbers[3],
                numbers[4], numbers[5], numbers[6], numbers[7], numbers[8], numbers[9]);
        }
    }
}