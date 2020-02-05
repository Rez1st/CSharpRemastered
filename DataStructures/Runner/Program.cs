using System;
using Queue;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var aq = new ArrayQueue<int>();

            var testArr = new int[10];
            testArr.FillRandom();

            Console.WriteLine($"Enqueue {testArr[0]}");
            aq.Enqueue(testArr[0]);

            Console.WriteLine($"Enqueue {testArr[1]}");
            aq.Enqueue(testArr[1]);

            Console.WriteLine($"Enqueue {testArr[2]}");
            aq.Enqueue(testArr[2]);

            Console.WriteLine($"Enqueue {testArr[3]}");
            aq.Enqueue(testArr[3]);

            Console.WriteLine($"Enqueue {testArr[4]}");
            aq.Enqueue(testArr[4]);

            Console.WriteLine($"Enqueue {testArr[5]}");
            aq.Enqueue(testArr[5]);

            Console.WriteLine($"Count {aq.Count}");

            Console.WriteLine($"Dequeue {aq.Dequeue()}");
            Console.WriteLine($"Dequeue {aq.Dequeue()}");

            Console.WriteLine($"Count {aq.Count}");

            Console.WriteLine($"Enqueue {testArr[6]}");
            aq.Enqueue(testArr[6]);

            Console.WriteLine($"Enqueue {testArr[7]}");
            aq.Enqueue(testArr[7]);

            Console.WriteLine($"Enqueue {testArr[8]}");
            aq.Enqueue(testArr[8]);

            Console.WriteLine($"Enqueue {testArr[9]}");
            aq.Enqueue(testArr[9]);

            Console.WriteLine($"Dequeue {aq.Dequeue()}");
            Console.WriteLine($"Dequeue {aq.Dequeue()}");
            Console.WriteLine($"Dequeue {aq.Dequeue()}");
            Console.WriteLine($"Dequeue {aq.Dequeue()}");

            Console.ReadKey();
        }
    }
}