using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGL
{

    internal class Program
    {
        static void Main(string[] args)
        {
            PowerState state = PowerState.NotDefined;

            if(state == PowerState.On)
            {
                Console.WriteLine("Es läuft...");
            }
            else if(state == PowerState.Exploded)
            {
                Console.WriteLine("Please call your administrator! :-)");
            }

            string[] names = Enum.GetNames(typeof(PowerState));
            foreach (var name in names)
            {
                Console.WriteLine($"\t- {name}");
            }

            switch (state)
            {
                case PowerState.On:
                    break;
                case PowerState.Off:
                    break;
                case PowerState.Standby:
                    break;
                case PowerState.Hibernating:
                    break;
                case PowerState.Exploded:
                    break;
                case PowerState.NotDefined:
                    break;
                default:
                    break;
            }
        }
    }
}
