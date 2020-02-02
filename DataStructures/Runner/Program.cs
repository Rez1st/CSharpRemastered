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
            var linkedStack = new LinkedStack<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedStack.Push(i);
                Console.WriteLine($"{i} pushed to stack");
            }

            while (linkedStack.Count > 0)
            {
                Console.WriteLine($"{linkedStack.Pop()} got from stack, items left : {linkedStack.Count}");
                
            }

            Console.ReadKey();
        }
    }
}
