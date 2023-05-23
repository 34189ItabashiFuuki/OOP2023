using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            var list = new List<string> {
               "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            //var exists = list.Exists(s => s[0] == 'A');
            //Console.WriteLine(exists);

            //var index = list.FindIndex(s => s == "Canberra");
            //Console.WriteLine(index);

            var names = list.ConvertAll(s => s.ToLower());
            names.ForEach(s => Console.WriteLine(s));
        }   
    }
}
