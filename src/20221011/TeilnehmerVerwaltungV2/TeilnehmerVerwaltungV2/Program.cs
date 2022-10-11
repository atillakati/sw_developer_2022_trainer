using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace TeilnehmerVerwaltungV2
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
            string eingabe = string.Empty;
            int xPos = 0;
            int participantCount = 0;
            bool isInputValid = false;
            Participant[] participantList;
            int age = 0;

            //Header
            CreateHeader(header, true);

            //get count of Teilnehmer
            participantCount = GetInt("Anzahl der Teilnehmer eingeben: ");
            
            //display header again
            CreateHeader(header, true);

            //get participant data
            participantList = GetParticipantData(participantCount);

            //output data
            for (int i = 0; i < participantList.Length; i++)
            {
                Console.WriteLine($"{participantList[i].Name}, {participantList[i].Location}");
            }

            Console.Write("\n\nWollen Sie diese Daten speicher(j/n): ");
            eingabe = Console.ReadLine();
            if (eingabe.ToLower() == "j")
            {
                using (StreamWriter sw = new StreamWriter("teilnehmerdaten.csv", true))
                {
                    for (int i = 0; i < participantList.Length; i++)
                    {
                        //save data            
                        string csvDataLine = $"{participantList[i].Name},{participantList[i].Surname},{participantList[i].Birthday.ToShortDateString()},{participantList[i].Location}";
                        sw.WriteLine(csvDataLine);  //schreibt eine Zeile inkl. Zeilenumbruch                                    
                    }
                }
            }


            #endregion
        }

        static Participant[] GetParticipantData(int participantCount)
        {
            Participant[] participantList = new Participant[participantCount];

            //get participant data
            for (int i = 0; i < participantList.Length; i++)
            {
                //start with participant data
                Console.WriteLine($"Teilnehmer {i + 1}:");
                participantList[i].Name = GetString("\tVorname: ");
                participantList[i].Name = GetString("\tNachname: ");
                participantList[i].Name = GetString("\tWohnort: ");
                participantList[i].Birthday = GetParticipantBirthday("\tGeburtsdatum: ");
            }

            return participantList;
        }

        static DateTime GetParticipantBirthday(string inputPrompt)
        {
            DateTime birthday = DateTime.MinValue;
            bool isInputValid = false;
            int age = 0;

            do
            {
                birthday = GetDateTime(inputPrompt);

                //age check
                age = DateTime.Now.Year - birthday.Year;
                if (age < 18 || age > 110)
                {
                    Console.Write("\aERROR: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Teilnehmer zu alt oder zu jung (min. 18 / max. 110).");
                    Console.WriteLine();
                    Console.ResetColor();
                    isInputValid = false;
                }
            } while (!isInputValid);

            return birthday;
        }

        static DateTime GetDateTime(string inputPrompt)
        {
            DateTime inputValue = DateTime.MinValue;
            bool isInputValid = false;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = DateTime.Parse(Console.ReadLine());
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
            } while (!isInputValid);

            return inputValue;
        }

        static string GetString(string inputPrompt)
        {
            string inputString = string.Empty;
            bool isInputValid = false;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                //null or empty check
                isInputValid = !string.IsNullOrEmpty(inputString);
            }
            while (!isInputValid);

            return inputString;
        }

        static int GetInt(string inputPrompt)
        {
            int intValue = 0;
            bool isInputValid = false;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    intValue = int.Parse(Console.ReadLine());
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

            return intValue;
        }

        static void CreateHeader(string header, bool clearScreen)
        {
            int xPos = 0;

            if (clearScreen)
            {
                Console.Clear();
            }

            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            xPos = (Console.WindowWidth - header.Length) / 2;
            Console.CursorLeft = xPos;
            Console.WriteLine(header);

            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.WriteLine();
        }
    }
}
