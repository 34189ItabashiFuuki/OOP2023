using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("＊＊売上集計＊＊");
            Console.WriteLine("１：店舗別売上");
            Console.WriteLine("２：商品カテゴリー別売上");
            Console.Write(">");
            int count = int.Parse(Console.ReadLine());
            var sales = new SalesCounter(@"data\sales.csv");
            if (count == 1)
            {
                var amountPerStone = sales.GetPerStoreSales();
                foreach (var obj in amountPerStone)
                {
                    Console.WriteLine("{0} {1:#,#}", obj.Key, obj.Value);
                }
            }
            else
            {
                var amountPerCategory = sales.GetPerProductCategorys();
                foreach (var obj in amountPerCategory)
                {
                    Console.WriteLine("{0} {1:#,#}", obj.Key, obj.Value);
                }
            }
        }
    }
}
