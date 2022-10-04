using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EingabenBeispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * Schreiben Sie eine Applikation, mit der die Fläche und 
            * der Umfang eines unregelmässigen Dreiecks berechnet werden kann.
            * 
            * - Sämtliche Seiten-Längen sollen von einem User eingegeben werden können.
            * - Ergebnisse und Eingaben sollen am Ende in einer ansprechenden Form 
            *   dargestellt werden.
            * - die Applikation soll Fehlertolerant sein (keine Exceptions)
            * - verwenden Sie Farben in der Ausgabe
            */

            //Lösung Flächenberechnung nach Heron: https://www.arndt-bruenner.de/mathe/9/herondreieck.htm

            //U = a + b + c
            //s = U/2
            //A = SQRT( s * (s-a) * (s-b) * (s-c) )

            //1. Programm Überschrift ausgeben/generieren
            //2. Seitenlängen einlesen (a, b, c)
            //   - einlesen
            //   - Gültigkeit prüfen/verifizieren 
            //3. Umfang berechnen - Fläche berechnen
            //4. Ausgabe der Seiten und Ergebnisse

            double A = 0.0;
            double U = 0.0;
            double s = 0.0;
            double a = 0.0;
            double b = 0.0;
            double c = 0.0;
            string eingabe = string.Empty;
            string headerText = "Berechnung allgemeines Dreieck";
            int xPos = 0;

            //1. Programm Überschrift ausgeben/generieren
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            xPos = (Console.WindowWidth - headerText.Length) / 2;
            Console.CursorLeft = xPos;
            Console.WriteLine(headerText);

            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.WriteLine();

            //2. Seitenlängen einlesen (a, b, c)
            Console.WriteLine("Bitte Seitenlängen eingeben!");
            Console.Write("\tSeite a: ");

            try
            {
                a = double.Parse(Console.ReadLine());

                Console.Write("\tSeite b: ");
                eingabe = Console.ReadLine();
                b = double.Parse(eingabe);

                Console.Write("\tSeite c: ");
                eingabe = Console.ReadLine();
                c = double.Parse(eingabe);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\a\nERROR: " + ex.Message);
                Console.ResetColor();
                return;
            }

            //3. Umfang berechnen - Fläche berechnen
            U = a + b + c;
            s = U / 2;
            A = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            //4. Ausgabe der Seiten und Ergebnisse
            Console.WriteLine("\nAngabe: ");
            Console.Write($"\tSeite a: {a:f2} | ");
            Console.Write($"\tSeite b: {b:f2} | ");
            Console.WriteLine($"\tSeite c: {c:f2}");
            Console.WriteLine("\nErgebnisse;");
            Console.WriteLine($"\tUmfang: {U:f2} | Fläche: {A:f2}");
        }
    }
}
