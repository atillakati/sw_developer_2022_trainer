using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFAnweisungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 20;

            if (zahl > 10 && zahl < 30)
            {
                Console.WriteLine("Die Zahl passt.");
            }
            else
            {
                Console.WriteLine("Leider keine gute Zahl.");
            }
            //else if ()
            //{

            //}
            //else
            //{

            //}

            zahl = 4;

            switch (zahl)
            {
                case 4:
                    Console.WriteLine("Das war eine Vier");
                    break;

                case 5:
                    Console.WriteLine("Das war eine Fünf");
                    break;

                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Das sind seltsame Werte");
                    break;

                default:
                    Console.WriteLine("Keine Ahnung.");
                    break;
            }


        }
    }
}
