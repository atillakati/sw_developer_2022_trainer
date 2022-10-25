using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int itemCount = 15;
            int initValue = -1;

            int[] meinZahlen = CreateArray(itemCount, initValue);

            //DateTime[] birthdayList = CreateDateTimeArray(itemCount, DateTime.MinValue);

            string[] namen = CreateArray<string>(5, "Hi");
            var birthdayList = CreateArray<DateTime>(5, DateTime.MinValue);
        }

        //Constraints
        private static T[] CreateArray<T>(int itemCount, T initValue) //where T: struct
        {            
            var values = new T[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                values[i] = initValue;
            }

            return values;
        }

        private static int[] CreateArray(int itemCount, int initValue)
        {
            var values = new int[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                values[i] = initValue;  
            }

            return values;
        }
    }
}
