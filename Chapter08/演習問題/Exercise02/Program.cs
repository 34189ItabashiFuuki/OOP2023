using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                

            }
        }
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var weeks = (int)dayOfWeek - (int)(date.DayOfWeek);

            

        }
    }
}
