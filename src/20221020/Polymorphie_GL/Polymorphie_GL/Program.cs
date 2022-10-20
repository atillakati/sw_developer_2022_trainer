using Polymorphie_GL.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphie_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = new Vehicle[]
            {
                new Vehicle("Badmobil", 250),
                new Motorbike("BMW", 190, ConsoleColor.Yellow),
                new Vehicle("Opel Vectra", VehicleType.Convertible, 150, ConsoleColor.Magenta)
            };

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

        }
    }
}
