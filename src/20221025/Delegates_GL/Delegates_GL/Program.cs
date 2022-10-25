using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_GL
{
    public delegate T OperationHandler<T>(T zahl1, T zahl2);

    internal class Program
    {
        static void Main(string[] args)
        {
            double zahl1 = 5.0;
            double zahl2 = 8.5;

            OperationHandler<double> op = Substraction;

            var res = Addition(zahl1, zahl2);

            res = op(zahl1, zahl2);
            res = op.Invoke(zahl1, zahl2);
            Console.Write(op.Method.Name + ": ");
            Console.WriteLine(res);            

            var alter = ConsoleTools.GetInt("Bitte Alter eingeben: ", MyMessageWriter);
        }

        private static void MyMessageWriter(Exception exception)
        {
            Console.WriteLine();
        }

        static double Addition(double z1, double z2)
        {
            return z1 + z2;
        }

        static double Substraction(double z1, double z2)
        {
            return z1 - z2;
        }
    }
}
