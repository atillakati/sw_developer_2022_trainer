using System;

namespace Eingaben_GL
{
    internal class Program
    {
        static void Main()
        {
            string name = string.Empty;
            string geburtsJahr = string.Empty;
            int geburtsJahrZahl = 0;
            int alter = 0;

            Console.Write("Bitte Name eingeben: ");
            name = Console.ReadLine();

            Console.WriteLine($"Hallo {name}!");

            Console.Write("Bitte Geburtsjahr eingeben: ");
            geburtsJahr = Console.ReadLine();
            // "1950" => 1950
            // "Alf" => ?

            geburtsJahrZahl = int.Parse(geburtsJahr);            

            alter = DateTime.Now.Year - geburtsJahrZahl;
            Console.WriteLine($"{name} ist {alter} Jahre alt.");


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
        }
    }
}
