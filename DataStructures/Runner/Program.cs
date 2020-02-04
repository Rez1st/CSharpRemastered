using System;
using Queue;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lq = new LinkedQueue<int>();

            var testArr = new int[10];
            testArr.Fill();

            foreach (var item in testArr)
            {
               lq.Enqueue(item); 
            }

            while (lq.Count >= 1)
            {
                Console.WriteLine(lq.Dequeue());
            }

            Console.ReadKey();
        }
    }
}