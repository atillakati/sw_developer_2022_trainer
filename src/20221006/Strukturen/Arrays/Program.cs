using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0;

            int[] zahlenListe = new int[8];

            zahlenListe[0] = -1;
            zahlenListe[1] = -1;
            zahlenListe[2] = -1;
            zahlenListe[3] = -1;
            zahlenListe[4] = -1;

            for (int i = 0; i < zahlenListe.Length; i++)
            {
                zahlenListe[i] = -1;
            }

        }
    }
}
