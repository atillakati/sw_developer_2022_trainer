using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WertUndReferenzTypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl1 = 5;
            int zahl2 = 8;

            zahl1 = zahl2;
            zahl2 = 2;

            Employee ma1 = new Employee("Mitarbeiter1", DateTime.Now);
            Employee ma2 = new Employee("Mitarbeiter2", DateTime.Now);

            ma1._salary = 500.0m;
            ma2._salary = 1500.0m;

            ma1 = ma2;
            ma2._salary = 2000.0m;

            Display(ma1);

            UpdateName(ma1);

            if(ma1 == ma2)
            {

            }

            Employee ma3;

            ma3._salary = 1500.0m;

            Console.WriteLine($"Zahl 1: {ma1._salary} Zahl 2: {ma2._salary}");

        }

        private static Employee UpdateName(Employee maToChange)
        {
            maToChange._salary = 0.0m;

            return maToChange;
        }

        private static void Display(Employee ma)
        {
            Employee mb = new Employee("Mitarbeiter1", DateTime.Now);

            mb = ma;
        }
    }
}
