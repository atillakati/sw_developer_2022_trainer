using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_GL
{
    public delegate void PrintSomething(string message, int headerLength);

    public delegate bool ItemCompareHandler(int item);

    internal class Program
    {
        static void Main(string[] args)
        {

            Action<string> printSomething = delegate (string message)
            {
                Console.WriteLine("Aufruf aus einer anonymen Methode:");
                Console.WriteLine(message);
            };

            printSomething = message => Console.WriteLine(message);


            printSomething("Dies ist ein Test...");

            int[] zahlenReihe = new[] { 1, 2, 4, 6, 7, 9, 10, 12, 13, 15, 16, 18, 19, 20, 22, 23, 25 };
            var result = Where(zahlenReihe, x => x < 10);

            result = zahlenReihe.Where(x => x > 5);
            result = zahlenReihe.Select(x => x + 2);            
        }

        static IEnumerable<T> Where<T>(IEnumerable<T> items, Predicate<T> itemCompareHandler)
        {
            var selectedItems = new List<T>();

            foreach (var item in items)
            {
                if (itemCompareHandler(item))
                {
                    selectedItems.Add(item);
                }
            }

            return selectedItems;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

    }
}
