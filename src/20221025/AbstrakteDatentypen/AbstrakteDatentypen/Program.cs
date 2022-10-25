using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myShapes = new Shape[]
            {
                new Circle("O1", 15.12),
                new Rectangle("R1", 8.65, 5.2),
                new Circle("Olaf", 25.12),
                new Rectangle("R2", 2.5, 2.6),
                new Rectangle("Richi", 12.5, 50.2)
            };

            foreach (var shape in myShapes)
            {
                shape.Draw();

                if(shape is IPrintable printable)
                {                    
                    PrintShapes(printable);
                }                
            }                    
        }
        
        static void PrintShapes(IPrintable printableShape)
        {
            if(printableShape != null)
            {
                printableShape.Print();
            }
        }
    }
}
