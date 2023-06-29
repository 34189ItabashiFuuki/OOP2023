using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            var abbrs = new Abbreviations();

            //addメソッドの呼び出し例
            abbrs.Add("IOC","国際オリンピック委員会");
            abbrs.Add("NTP", "核兵器不拡散条約");

            //インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NTP" };
            foreach(var name in names)
            {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0} = {1}", name, fullname);
            }
            Console.WriteLine(); //改行

            //ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0}は見つかりません", japanese);
            else
                Console.WriteLine("{0} = {1}", japanese, abbreviation);

            //FillAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際"))
            {
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
    }
}
