using System;
using Stack;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            args = new[] {"5", "6", "*"};
            var calc = new PostfixCalculator();

            Console.WriteLine(calc.Process(args));

            Console.ReadKey();
        }
    }
}