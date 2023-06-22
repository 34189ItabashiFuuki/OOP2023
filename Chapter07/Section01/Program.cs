using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            /*var flowerDict = new Dictionary<string, int>() {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahliia"] = 450,
            };

            //morning glory(あさがお)250円を追加
            flowerDict["morning glory"] = 250;

            Console.WriteLine("ひまわりの価格は{0}円です。", flowerDict["sunflower"]);
            Console.WriteLine("チューリップの価格は{0}円です。", flowerDict["tulip"]);
            Console.WriteLine("あさがおの価格は{0}円です。", flowerDict["morning glory"]);*/

            var prefDict = new Dictionary<string, string>();
            string pref, city;


            Console.WriteLine("県庁所在地の登録");
            Console.Write("県名：");
            pref = Console.ReadLine();

            while (pref != "999") {
                Console.Write("所在地：");
                city = Console.ReadLine();
                
                if (prefDict.ContainsKey(pref)) {
                    Console.WriteLine("既に登録してあります。上書きしますか？");
                    Console.Write("はい / いいえ : ");
                    var ans = Console.ReadLine();
                    if (ans == "はい") {
                        prefDict[pref] = city;
                    }
                }
                else {
                    prefDict[pref] = city;
                }

                Console.Write("県名：");
                pref = Console.ReadLine();
            }

            Console.WriteLine("1:一覧表示,2:県名指定");
            int answer = int.Parse(Console.ReadLine());

            if (answer == 1) {
                foreach (var item in prefDict) {
                    Console.WriteLine("{0} = {1}", item.Key, item.Value);
                }
            }
            else {
                Console.Write("県名：");
                pref = Console.ReadLine();
                Console.WriteLine("{0}です。", prefDict[pref]);
            }
        }
    }

    class CityInfo {
        string City { get; set; }
        string Population { get; set; }
    }
}
