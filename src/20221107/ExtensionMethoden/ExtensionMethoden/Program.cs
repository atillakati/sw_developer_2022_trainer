using System;
using System.Linq;

namespace ExtensionMethoden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var zahlenListe = new[] { 1, 5, 6, 4, 2, 5, 98, 56, 2, 5, 2 };

            string[] namensListe;

            zahlenListe.Display();

            zahlenListe.Increase()
                       .Increase()
                       .Decrease();

            zahlenListe.Where(x => x > 2)
                       .Select(x => x * 3);


        }
    }
}
