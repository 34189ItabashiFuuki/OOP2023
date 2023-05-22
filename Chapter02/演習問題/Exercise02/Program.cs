using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            
            if(args.Length < 3){
                return;
            }

            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);
            
            if(args[0] == "-tom")
            {
                PrintInchToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            }
            else if(args[0] == "-toi")
            {
                PrintMeterToInchList(int.Parse(args[1]), int.Parse(args[2]));
            }
        }

        private static void PrintInchToMeterList(int start, int stop) {
            for(int inch = start; inch <= stop; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} inch = {1:0.0000}m,", inch, meter);
            } 
        }

        private static void PrintMeterToInchList(int start, int stop) {
            for(int meter = start; meter <= stop; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000}inch,", meter, inch);
            }
        }
    }
}
