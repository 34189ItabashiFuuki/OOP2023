using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise06 {
    class Program {
        static void Main(string[] args) {
            var text = "しるし しんぶんし きたのたき きもの いろしろい トマト ヨクナクヨ ";

            var pattern = @"\b(\w)(\w)\w\2\1\b"; //←ここにパターンを記述
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }
    }
}
