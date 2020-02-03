using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using LinkedList;
using Stack;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dataLink = new DataLink<string>();

            //for (var i = 0; i < 10; i++)
            //{
            //    dataLink.Add($"String number {i}");
            //}

            //foreach (var d in dataLink)
            //{
            //    Console.WriteLine(d);
            //}

            // Stack
            var arrayStack = new ArrayStack<int>();

            for (int i = 0; i < 10; i++)
            {
                arrayStack.Push(i);
                Console.WriteLine($"{i} pushed to stack");
            }

            while (arrayStack.Count > 0)
            {
                Console.WriteLine($"{arrayStack.Pop()} got from stack, items left : {arrayStack.Count}");
            }

            Console.ReadKey();
        }
    }
}
