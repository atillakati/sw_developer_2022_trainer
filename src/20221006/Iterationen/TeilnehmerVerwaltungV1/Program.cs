using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeilnehmerVerwaltungV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * Wir wollen eine kleine Applikation zur (Kurs)Teilnehmerverwaltung schreiben.
             * 1.) Folgende Daten pro Teilnehmer sollen eingelesen werden:
             * 
             * - Name + Vorname
             * - Geburtsdatum
             * - Wohnort
             * 
             * 2.) Es sollen beliebig viele Teilnehmer erfasst werden.
             * 
             * 3.) Teilnehmer-Daten (=alle Daten pro Session in eine Datei) 
             *     sollen in einer csv-Datei gespeichert werden.
             *     Aufbau der csv-Datei:
             *     [Vorname],[Nachname],[Geb.Datum],[Wohnort]
             *     
             * */

            //schreiben in eine Datei:
            StreamWriter sw = new StreamWriter("teilnehmerdaten.csv", true);
            sw.WriteLine();  //schreibt eine Zeile inkl. Zeilneumbruch
            Console.WriteLine();

            sw.Close();

            /* 4.) autom. Altersbeschränkung einbauen ==> T > 18 < 110 Jahre
             * 5.) Fehlertolerante Umsetzung, d.h. Fehleingaben führen zu Wiederholung
             * 
             * 
             */
        }
    }
}
