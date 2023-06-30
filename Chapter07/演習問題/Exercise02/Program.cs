using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            //コンストラクタの呼び出し
            var abbrs = new Abbreviations();

            //Addメソッドの呼び出し
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NTP", "核兵器不拡散条約");

            //7.2.3
            //上のAddメソッドで。２つのオブジェクトを追加しているので、読み込み

            int count = abbrs.Count;
            Console.WriteLine(count);

            //7.2.3(Removeの呼び出し)
            Console.WriteLine("けすやつ");
            var remove = Console.ReadLine();
            abbrs.Remove(remove);


            //7.2.4
            //IEnumerabl<>を実装したので、LINQが使える。
            abbrs.abbs();


        }
    }
}
