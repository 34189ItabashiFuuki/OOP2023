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

            var prefDict = new Dictionary<string,CityInfo>();
            string pref;
            

            Console.WriteLine("県庁所在地の登録");
            Console.Write("県名：");
            pref = Console.ReadLine();

            while (pref != "999") {
                var cityinfo = new CityInfo();
                Console.Write("所在地：");
                cityinfo.City = Console.ReadLine();
                Console.Write("人口：");
                cityinfo.Population =int.Parse(Console.ReadLine());
                
                if (prefDict.ContainsKey(pref)) {
                    Console.WriteLine("既に登録してあります。上書きしますか？");
                    Console.Write("はい / いいえ : ");
                    var ans = Console.ReadLine();
                    if (ans == "はい") {
                        prefDict[pref] = cityinfo;
                    }
                }
                else {
                    prefDict[pref] = cityinfo;
                }
                Console.Write("県名：");
                pref = Console.ReadLine();
            }

            Console.Write("1:一覧表示,2:県名指定 ＞＞ ");
            int answer = int.Parse(Console.ReadLine());

            if (answer == 1) {
                foreach (var item in prefDict) {
                    Console.WriteLine("{0}【{1}(人口：{2}人)】", item.Key, item.Value.City, item.Value.Population);
                }
            }
            else {
                Console.Write("県名：");
                pref = Console.ReadLine();
                Console.WriteLine("所在地：{0}", prefDict[pref].City);
                Console.WriteLine("人口：{0}", prefDict[pref].Population);
            }
        }
    }

    class CityInfo {
        public string City { get; set; }　//都市
        public int Population { get; set; } //人口
    }
}
