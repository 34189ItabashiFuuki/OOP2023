using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosoleApp0411 {
    class Program {
        static void Main(string[] args) {

            /*string[] moneyString = { "一万円","五千円","二千円","千円","五百円","百円","五十円","十円","五円","一円" };
            int[] moneyInteger = { 10000,5000,2000,1000,500,100,50,10,5,1};*/
            Console.Write("金額：");
            int count = int.Parse(Console.ReadLine());
            Console.Write("支払：");
            int pay = int.Parse(Console.ReadLine());
            int change = pay - count;
            Console.WriteLine("お釣：" + change);

            /*for (int i = 0; i < moneyString.Length; i++)
            {
                Console.WriteLine(moneyString[i] + ":{0}円",change/ moneyInteger[i]);
                Console.Write(moneystring[i] + "：");
                astOut(change/moneyInteger[i]);
                change %= moneyInteger[i];
            }*/


           
            Console.Write("一万円：");
            for (int i = 0; i < change / 10000; i++)
            {
                Console.Write("*");
            }
            change = change % 10000;
            Console.WriteLine();

            Console.Write("五千円：");
            for (int i = 0; i < change / 5000; i++)
            { 
                Console.Write("*");
            }
            change = change % 5000;
            Console.WriteLine();

            Console.Write("二千円：");
            for (int i = 0; i < change / 2000; i++)
            {
                Console.Write("*");
            }
            change = change % 2000;
            Console.WriteLine();

            Console.Write("千円：");
            for (int i = 0; i < change / 1000; i++)
            {
                Console.Write("*");
            }
            change = change % 1000;
            Console.WriteLine();

            Console.Write("五百円：");
            for (int i = 0; i < change / 500; i++)
            {
                Console.Write("*");
            }
            change = change % 500;
            Console.WriteLine();

            Console.Write("百円：");
            for (int i = 0; i < change / 100; i++)
            { 
                Console.Write("*");
            }
            change = change % 100;
            Console.WriteLine();

            Console.Write("五十円：");
            for (int i = 0; i < change / 50; i++)
            {
                Console.Write("*");
            }
            change = change % 50;
            Console.WriteLine();

            Console.Write("十円：");
            for (int i = 0; i < change / 10; i++)
            {
                Console.Write("*");
            }
            change = change % 10;
            Console.WriteLine();

            Console.Write("五円：");
            for (int i = 0; i < change / 5; i++)
            {
                Console.Write("*");
            }
            change = change % 5;
            Console.WriteLine();

            Console.Write("一円：");
            for (int i = 0; i < change / 1; i++)
            {
                Console.Write("*");
            }
            change = change % 1;
            Console.WriteLine();

        }
        //指定した個数の"*"を出力する
        /*private static void astOut(int count) {
            for (int i = 0; i < count; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();//改行
        }*/
    }
}
