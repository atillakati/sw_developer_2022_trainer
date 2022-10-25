using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_GL
{
    public delegate void PrintSomething(string message);
    public delegate void PrintSomethingEmpty();

    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSomething printSomething = delegate (string message) 
            {
                Console.WriteLine("Aufruf aus einer anonymen Methode:");
                Console.WriteLine(message);
            };

            printSomething("Test");

            printSomething = (string message) =>
            {
                Console.WriteLine("Aufruf aus einer anonymen Methode:");
                Console.WriteLine(message);
            };

            printSomething = message =>
            {
                Console.WriteLine("Aufruf aus einer anonymen Methode:");
                Console.WriteLine(message);
            };


            PrintSomethingEmpty empty = () => Console.WriteLine();
            empty = WriteEmpty;
        }

        private static void WriteEmpty()
        {
            Console.WriteLine();
        }
    }
}
