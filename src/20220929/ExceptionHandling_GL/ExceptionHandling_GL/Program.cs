using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabe = "8654654654654654654654654";
            int zahl = 0;

            try
            {
                zahl = int.Parse(eingabe);
                Console.WriteLine($"Zahl: {zahl}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ungültige Eingabe: {ex.Message}");
            }            
        }
    }
}
