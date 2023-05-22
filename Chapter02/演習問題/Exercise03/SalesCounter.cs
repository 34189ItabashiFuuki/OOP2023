using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    public class SalesCounter {

        private IEnumerable<Sale> _sales;
        
        //コンストラクタ
        public SalesCounter(string filepath) {
            _sales = ReadSales(filepath);
        }
        
        //店舗別売上を求める
        public IDictionary<string, int> GetPerStoreSales() {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales)
            {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount; //店名が既に存在する
                else
                    dict[sale.ShopName] = sale.Amount;//店名が存在しない 
            }
            return dict;
        }
        //カテゴリー別売上
        public IDictionary<string, int> GetPerProductCategorys() {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales)
            {
                if (dict.ContainsKey(sale.ProductCategory))
                    dict[sale.ProductCategory] += sale.Amount; //店名が既に存在する
                else
                    dict[sale.ProductCategory] = sale.Amount;//店名が存在しない 
            }
            return dict;
        }
        //売上データ読み込み、Saleオブジェクトのリストを返す
        private static IEnumerable<Sale> ReadSales(string filePath) {
            var sales = new List<Sale>();//売り上げデータを格納
            string[] lines = File.ReadAllLines(filePath);//ファイルからすべてのデータを読み込み

            foreach (var line in lines)//すべての行から一行ずつ取り出す
            {
                var items = line.Split(',');//区切りで項目別に分ける
                var sale = new Sale//Saleインスタンスを生成
                {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);//Saleインスタンスをコレクションに追加
            }
            return sales;
        }
    }
}    

