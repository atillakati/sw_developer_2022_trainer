using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenTypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            int zahl;

            //Console.WriteLine(zahl); ==> GEHT NICHT!

            //Initialisierung
            zahl = 5;

            //Deklaration & Initialisierung
            int zahl2 = 0;

            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);

            string vorName = "Gandalf";
            vorName = string.Empty;

            bool isPowerOn = true;

            double gewicht = 15.654655;

            decimal gehalt = 1654.321m;

            char sign = 'd';
        }
    }
}
