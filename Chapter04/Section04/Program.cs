using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {

            #region 条件演算子            
            var list = new List<int> { 10, 20, 30, 40, };
            var key = 40;

            var num = list.Contains(key) ? 1 : 0;//条件演算子・三項演算子
            Console.WriteLine(num);
            #endregion

            #region null合体演算子
            string code = "12345";
            var message = GetMessage(code) ?? DefaultMessege();
            Console.WriteLine(message);
            #endregion
        }

        private static object GetMessage(object code) {
            return 123;
        }

        private static object DefaultMessege() {
            return "Default Message";
        }
    }
}
