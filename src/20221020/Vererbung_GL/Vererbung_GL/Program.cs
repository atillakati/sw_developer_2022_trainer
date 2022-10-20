using System;
using Vererbung_GL.VehicleTypes;

namespace Vererbung_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var superCar = new Vehicle("Badmobil", 250);
            var superBike = new Motorbike("BMW", 190, ConsoleColor.Yellow);

            var vehicleList = new Vehicle[] { superCar, superBike };

            foreach (var fahrzeug in vehicleList)
            {
                DoService(fahrzeug);
            }
        }

        private static void DoService(Vehicle vehicle)
        {
            Console.WriteLine($"Starte mit dem Service für: \n{vehicle.DisplayStats()}");
            //...
            //..
            Console.WriteLine("Service abgeschlossen.\n");
        }
    }
}
