using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL_Klassen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee mitarbeiter = new Employee("Sauron", new DateTime(1920,9,20));
            Employee mitarbeiter2 = new Employee("Gandalf", new DateTime(1980,6,18));

            //init
            //mitarbeiter.Name = "Gandalf";
            //mitarbeiter.Birthday = new DateTime(1978, 5, 12);
            //mitarbeiter.Id = Guid.NewGuid();
            //mitarbeiter.Salary = 1854.654m;

            //display
            mitarbeiter.Display();

            mitarbeiter.AdaptSalary(-5000);
            //mitarbeiter.Salary = -5002.654m;

            Console.WriteLine($"{mitarbeiter.Name} - ");
            mitarbeiter.Name = "Gandalf Sehrweise";            

            mitarbeiter.Display();
            mitarbeiter2.Display();
        }
    }
}
