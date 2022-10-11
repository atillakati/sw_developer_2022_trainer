using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintHelloWorld();
            PrintHelloWorld();
            PrintHelloWorld();
            PrintHelloWorld();

            PrintMessage("Ich bin Gandalf!");

            string text = "Hallo du!";
            PrintMessage(text);

            PrintColoredMessage("Dies ist ein Test.", ConsoleColor.Red);
            
            PrintColoredMessage(text, ConsoleColor.Green);

            double summe = Add(5.0, 8.2);
            PrintColoredMessage(summe.ToString(), ConsoleColor.Yellow);
            Console.WriteLine($"Ergebnis: {summe:f2}");            
           
        }

        //Signatur
        //Rückgabetype Methodenname ( Parameter )

        private static double Add(double number1, double number2)
        {
            double erg = number1 + number2;

            return erg;
        }


        private static void PrintColoredMessage(string message, ConsoleColor messageColor)
        {
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
            
            Console.ResetColor();
        }

        private static void PrintMessage(string messageToDisplay)
        {
            Console.WriteLine(messageToDisplay);    
        }


        /// <summary>
        /// Gibt 'HelloWorld' auf den Bildschirm aus.
        /// </summary>
        private static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

    }
}
