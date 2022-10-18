using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace KapselungBeispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle badMobil = new Vehicle("BadMobil V2turbo", VehicleType.SportsCar, 350, ConsoleColor.Yellow);

            Motorbike bike = new Motorbike("BMW", 180, ConsoleColor.Red);

            Console.WriteLine(bike.DisplayStats());

            //Console.WriteLine(badMobil.DisplayStats());

            //badMobil.SpeedUp(150);
            //Console.WriteLine(badMobil.DisplayStats());
        }
    }
}
