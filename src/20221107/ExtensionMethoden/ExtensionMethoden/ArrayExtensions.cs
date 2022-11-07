using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethoden
{
    internal static class ArrayExtensions
    {
        public static void Display(this int[] zahlen)
        {
            foreach (var item in zahlen)
            {
                Console.Write(item + " - ");
            }

            Console.WriteLine();
        }

        public static int[] Increase(this int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] += 2;
            }            

            return zahlen;
        }

        public static int[] Decrease(this int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] -= 2;
            }

            return zahlen;
        }

    }
}
