using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    
    class Program {
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンスを生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daifuku = new Product(235, "大福もち", 160);

            //Console.WriteLine("かりんとうの税込価格：" + karinto.GetPriceIncludingTax());
            //Console.WriteLine("大福もちの税込価格：" + daifuku.GetPriceIncludingTax());
            #endregion

            #region 演習１
            //DateTime date = new DateTime(2023,5,8);
            DateTime date = DateTime.Today;

            Console.WriteLine("今日は{0}年{1}月{2}日です。" ,date.Year,date.Month,date.Day);

            //10日後を求める
            DateTime daysAfter10 = date.AddDays(10);
            Console.WriteLine("今日の10日後は{0}年{1}月{2}日です。", daysAfter10.Year, daysAfter10.Month, daysAfter10.Day);

            //10日前を求める
            DateTime daysBefore10 = date.AddDays(-10);
            Console.WriteLine("今日の10日後は{0}年{1}月{2}日です。", daysBefore10.Year, daysBefore10.Month, daysBefore10.Day);
            #endregion
           
            #region 演習２
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int seireki = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());

            DateTime birthday = new DateTime(seireki, month, day);
            DateTime today = new DateTime(2023, 5, 9);

            TimeSpan interval = today - birthday;

            Console.Write("あなたは生まれてから今日まで{0}日目です。", interval.Days);

            #endregion
        }
    }
}
