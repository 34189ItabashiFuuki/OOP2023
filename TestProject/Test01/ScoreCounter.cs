using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();//点数を格納
            string[] lines = File.ReadAllLines(filePath);//データを読み込み
            foreach (var line in lines)
            {//すべての行から一行ずつ取り出す
                var items = line.Split(',');//区切りで項目別に分ける
                var score = new Student//Studentインスタンスを生成
                {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                scores.Add(score);//Studentインスタンスをコレクションに追加
            }
            return scores;
        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new SortedDictionary<string, int>();
            foreach (var score in _score) { 
                if (dict.ContainsKey(score.Subject))
                    dict[score.Subject] += score.Score; 
                else
                    dict[score.Subject] = score.Score;
            }
            return dict;
        }
    }
}
