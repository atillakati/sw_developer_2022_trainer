using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Tools
{
    public abstract class ConsoleTools
    {
        public static DateTime GetDateTime(string inputPrompt)
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

        public static string GetString(string inputPrompt)
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

        public static int GetInt(string inputPrompt)
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

        /// <summary>
        /// aewsdgfdsaf
        /// </summary>
        /// <param name="header"></param>
        /// <param name="clearScreen"></param>
        public static void CreateHeader(string header, bool clearScreen)
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
