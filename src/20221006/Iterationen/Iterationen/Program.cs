using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Gandalf";



            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Aktueller Wert: {i}");
                i--;

                i = 5;
            }
            
            //int i;
            //int j = 3;
            //for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}"))
            //{
            //    //...
            //}

            bool inputIsValid = false;

            while (!inputIsValid)
            {
                Console.WriteLine("Tu was...");
                inputIsValid = true;
            }

            do
            {
                Console.WriteLine("Tu was...");
                inputIsValid = true;
            }
            while (!inputIsValid);


        }
    }
}
