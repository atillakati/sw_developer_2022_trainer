using System;

namespace Operatoren_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //arithmetische Operatoren
            // +  - * / %            
            int a = 4;
            int b = 2;
            int summe = 0;

            summe = 8 * (a + b) - 15;
            //summe = Math.Sin()

            //logische Operatoren
            // & | && || ! >>  <<
            bool isPowerOn = true;
            bool dataValid = false;

            bool processing = isPowerOn && dataValid;
            processing = !dataValid;
            //if(data != null && data.IsValid )
            //{

            //}

            //Vergleichsoperatoren
            // < > == != <= >=

            //Zusammengesetzte Operatoren
            int zahl = 10;

            zahl = zahl / 5;
            zahl /= 5;

            zahl = zahl + 1;
            zahl += 1;
            zahl++;  //Increment - Dekrement
            zahl--;

            ++zahl;
        }
    }
}
