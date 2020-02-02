using System;
using System.Threading.Tasks.Dataflow;
using LinkedList;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLink = new DataLink<string>();

            for (var i = 0; i < 10; i++)
            {
                dataLink.Add($"String number {i}");
            }

            foreach (var d in dataLink)
            {
                Console.WriteLine(d);
            }

            Console.ReadKey();
        }
    }
}
