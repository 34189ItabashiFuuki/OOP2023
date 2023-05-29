using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {

            #region 条件演算子            
            /*var list = new List<int> { 10, 20, 30, 40, };
            var key = 40;

            var num = list.Contains(key) ? 1 : 0;//条件演算子・三項演算子
            Console.WriteLine(num);*/
            #endregion

            #region null合体演算子
            /*string code = "12345";
            var message = GetMessage(code) ?? DefaultMessege();
            Console.WriteLine(message);*/
            #endregion

            #region null条件演算子
            Sale sale = new Sale {
                Amount = 100,
            };
            //「int」はnull許容型、「?.」はnull条件演算子
            int? ret = sale?.Amount;
            Console.WriteLine(ret);
            #endregion
        }
        private static object GetMessage(object code) {
            return 123;
        }
        private static object DefaultMessege() {
            return "Default Message";
        }
    }
    //売上クラス
    public class Sale {
        //店舗名
        public string ShopName { get; set; }
        //商品カテゴリー
        public string ProductCategory { get; set; }
        //売上高
        public int Amount { get; set; }
    }
}



