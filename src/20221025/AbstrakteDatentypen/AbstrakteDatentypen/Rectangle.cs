using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Rectangle : Shape, IPrintable
    { 
        private double _width;
        private readonly string _bezeichnung;
        private double _length;

        public Rectangle(string bezeichnung, double length, double width) : base()
        {
            _bezeichnung = bezeichnung;
            _length = length;
            _width = width;
        }

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public override string Name
        {
            get { return _bezeichnung; }
        }

        public override void Draw()
        {
            Console.WriteLine(GetInfos());
        }

        public override string GetInfos()
        {
            return $"Rectangle {Name}: h = {_length} / b = {_width}";
        }

        public void Print()
        {
            Console.WriteLine($"Rectangle wird gedruckt...");
        }
    }
}
