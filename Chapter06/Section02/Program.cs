using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var numbers = Enumerable.Range(1, 1000000).ToArray();
            WriteTotalMemory("配列確保後");

            //偶数だけ取り出す
            var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            WriteTotalMemory("偶数抽出後");

            var average = evenNumbers.Average();
            WriteTotalMemory("偶数抽出後平均");
            Console.WriteLine("実行時間 = {0}", sw.Elapsed.ToString(@"ss\.fffff"));//時間表示


        }
        static void WriteTotalMemory(string header) {
            var totalMemory = GC.GetTotalMemory(true) / 1024.0 / 1024.0;
            Console.WriteLine($"{header}: {totalMemory:0.000 MB}");
        }
    }
}
