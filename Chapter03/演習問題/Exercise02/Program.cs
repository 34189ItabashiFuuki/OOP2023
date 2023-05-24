using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine();
            Exercise2_2(names);
            Console.WriteLine();
            Exercise2_3(names);
            Console.WriteLine();
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力");
            
            do{
            
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                int index = names.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            var city = names.Count(s => s.Contains( 'o' ));
            Console.WriteLine(city);
        }

        private static void Exercise2_3(List<string> names) {
            var query = names.Where(x => x.Contains( 'o' ));
            foreach (var city in query)
            {
                Console.WriteLine("{0}", city);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var query = names.Where(x => x.StartsWith("B"))
                .Select(x => new { x,x.Length});

            foreach(var item in query){
                Console.WriteLine("{0},{1}", item.x, item.Length);
            }
        }
    }
}
