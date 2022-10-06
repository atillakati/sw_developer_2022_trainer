using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Strukturen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0;
            Teilnehmer teilnehmer = new Teilnehmer();

            teilnehmer.Name = "Gandalf";
            teilnehmer.Nachname= "Sehralt";
            teilnehmer.Wohnort = "Mittelerde";
            teilnehmer.Geburtsdatum = DateTime.Today;

            Console.WriteLine(teilnehmer);
        }
    }
}
