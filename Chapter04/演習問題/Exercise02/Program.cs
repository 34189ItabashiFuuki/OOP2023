using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach(var item in ymCollection) {
                Console.WriteLine(item);
            }
        }

        //4.2.3
        static YearMonth FindFirst21C(YearMonth[] yms) {
            foreach (var item in yms){
                if(item.Is21Century) {
                    return item;
                }
            }
            return null;
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            if (FindFirst21C(ymCollection) == null) {
                Console.WriteLine("２１世紀のデータはありません。");
            }
            else {
                Console.WriteLine(FindFirst21C(ymCollection).Year);
            }
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();

            Exercise2_2(array);
        }
    }
}
