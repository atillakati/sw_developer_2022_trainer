using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WertUndReferenzTypen
{
    internal class Employee
    {
        private string _name;
        private Guid _id;
        private DateTime _birthday;
        public decimal _salary;

        //std. Konstruktor
        //public Employee() 
        //{
        //    Name = "Max Mustermann";
        //    Id = Guid.NewGuid();
        //    Birthday = DateTime.MinValue;
        //    Salary = 800;
        //}

        //benutz. Konstruktor
        public Employee(string name, DateTime birthday)
        {
            _name = name;
            _birthday = birthday;

            _id = Guid.NewGuid();
            _salary = 800;
        }

        ////Änderungs- und Zugriffsmethoden
        //public decimal get_Salary()
        //{
        //    return Salary;
        //}

        //public string get_Name()
        //{
        //    return Name;
        //}

        //public void set_Name(string newName)
        //{
        //    if (!string.IsNullOrEmpty(newName))
        //    {
        //        Name = newName;
        //    }
        //}

        //public Guid GetId()
        //{
        //    return Id;
        //}

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        public void AdaptSalary(decimal delta)
        {
            if (delta > 1000 || delta < -1000 || _salary + delta < 0)
            {
                return;
            }

            _salary += delta;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {_id} - {_name}");
            Console.WriteLine($"Alter: {DateTime.Now.Year - _birthday.Year} Gehalt: EUR {_salary:f2}");
        }
    }
}
