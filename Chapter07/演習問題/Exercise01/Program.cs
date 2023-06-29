using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();
            Exercise1_2(text);
        }

        private static void Exercise1_1(string text) {
            var alphabetdict = new Dictionary<Char, int>();
            foreach (var alphabet in text.ToUpper().Where(i => i != ' ')) {
                if ('A' <= alphabet && alphabet <= 'Z') {
                    if (alphabetdict.ContainsKey(alphabet)) {
                        alphabetdict[alphabet]++;
                    }
                    else {
                        alphabetdict[alphabet] = 1;
                    }
                }
            }
            foreach (var item in alphabetdict.OrderBy(a => a.Key)) {
                Console.WriteLine("{0} = {1}",item.Key,item.Value);
            }
        }

        private static void Exercise1_2(string text) {
            var alphabetdict = new SortedDictionary<Char, int>();
            foreach (var alphabet in text.ToUpper().Where(i => i != ' ')) {
                if ('A' <= alphabet && alphabet <= 'Z') {
                    if (alphabetdict.ContainsKey(alphabet)) {
                        alphabetdict[alphabet]++;
                    }
                    else {
                        alphabetdict[alphabet] = 1;
                    }
                }
            }
            foreach (var item in alphabetdict) {
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            }







        }
    }
}
