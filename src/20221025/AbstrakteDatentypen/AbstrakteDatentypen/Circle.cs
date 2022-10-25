using System;
using System.Runtime.InteropServices;

namespace AbstrakteDatentypen
{
    internal class Circle : Shape
    {
        private double _radius;
        private string _name;

        public Circle(string bezeichnung, double radius) : base()
        {
            _name = bezeichnung;
            _radius = radius;
        }

        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override void Draw()
        {
            Console.WriteLine(GetInfos());
        }

        public override string GetInfos()
        {
            return $"Circle - {Name} r = {_radius}";
        }
    }
}
