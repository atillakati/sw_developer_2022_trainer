using System;
using System.IO;

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
            //StreamWriter sw = new StreamWriter("teilnehmerdaten.csv", true);
            //sw.WriteLine();  //schreibt eine Zeile inkl. Zeilneumbruch
            //Console.WriteLine();

            //sw.Close();

            /* 4.) autom. Altersbeschränkung einbauen ==> T > 18 < 110 Jahre
             * 5.) Fehlertolerante Umsetzung, d.h. Fehleingaben führen zu Wiederholung
            */

            #region Implementation

            string header = "Teilnehmer Verwaltung V1.0";
            int xPos = 0;
            int participantCount = 0;
            bool isInputValid = false;
            Participant[] participantList;
            int age = 0;

            //Header
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            xPos = (Console.WindowWidth - header.Length) / 2;
            Console.CursorLeft = xPos;
            Console.WriteLine(header);

            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.WriteLine();

            //get count of Teilnehmer
            do
            {
                try
                {
                    Console.Write("Anzahl der Teilnehmer eingeben: ");
                    participantCount = int.Parse(Console.ReadLine());
                    isInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.Write("\aERROR: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                    isInputValid = false;
                }
            }
            while (!isInputValid);

            participantList = new Participant[participantCount];

            //get participant data
            for (int i = 0; i < participantList.Length; i++)
            {
                //display header again
                Console.Clear();
                Console.WriteLine(new string('#', Console.WindowWidth - 1));

                xPos = (Console.WindowWidth - header.Length) / 2;
                Console.CursorLeft = xPos;
                Console.WriteLine(header);

                Console.WriteLine(new string('#', Console.WindowWidth - 1));
                Console.WriteLine();

                //start with participant data
                Console.WriteLine($"Teilnehmer {i + 1}:");
                do
                {
                    Console.Write("\tVorname: ");
                    participantList[i].Name = Console.ReadLine();
                    isInputValid = !(string.IsNullOrEmpty(participantList[i].Name) || participantList[i].Name.Length == 0);
                }
                while (!isInputValid);

                do
                {
                    Console.Write("\tNachname: ");
                    participantList[i].Surname = Console.ReadLine();
                    isInputValid = !(string.IsNullOrEmpty(participantList[i].Surname) || participantList[i].Surname.Length == 0);
                }
                while (!isInputValid);

                do
                {
                    Console.Write("\tWohnort: ");
                    participantList[i].Location = Console.ReadLine();
                    isInputValid = !(string.IsNullOrEmpty(participantList[i].Location) || participantList[i].Location.Length == 0);
                }
                while (!isInputValid);

                do
                {
                    try
                    {
                        Console.Write("\tGeburtsdatum: ");
                        participantList[i].Birthday = DateTime.Parse(Console.ReadLine());
                        isInputValid = true;

                        //age check
                        age = DateTime.Now.Year - participantList[i].Birthday.Year;
                        if (age < 18 || age > 110)
                        {
                            Console.Write("\aERROR: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Teilnehmer zu alt oder zu jung (min. 18 / max. 110).");
                            Console.WriteLine();
                            Console.ResetColor();
                            isInputValid = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("\aERROR: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                        Console.ResetColor();
                        isInputValid = false;
                    }
                } while (!isInputValid);

                //save data
                string csvDataLine = $"{participantList[i].Name},{participantList[i].Surname},{participantList[i].Birthday.ToShortDateString()},{participantList[i].Location}";
                StreamWriter sw = new StreamWriter("teilnehmerdaten.csv", true);
                sw.WriteLine(csvDataLine);  //schreibt eine Zeile inkl. Zeilenumbruch                
                sw.Close();
            }
            #endregion
        }
    }
}
