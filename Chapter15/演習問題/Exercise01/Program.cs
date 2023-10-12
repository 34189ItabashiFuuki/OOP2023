using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Where(b => b.Price == Library.Books.Max(m => m.Price));
            foreach (var maxbook in max) {
                Console.WriteLine(maxbook);
            }
        }

        private static void Exercise1_3() {
            var publishedyear = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(g => g.Key);
            foreach (var count in publishedyear) {
                Console.WriteLine(count.Key + "年:"+ count.Count() + "冊");
            }
        }

        private static void Exercise1_4() {
            var publishedyear = Library.Books.Join(Library.Categories,
                                                    book => book.CategoryId,
                                                    category => category.Id,
                                                    (book, category) => new {
                                                        book.PublishedYear,
                                                        book.Price,
                                                        book.Title,
                                                        CategoryName = category.Name,
                                                    })
                                                    .OrderByDescending(x => x.PublishedYear)
                                                    .ThenByDescending(x => x.Price);
            foreach (var p in publishedyear) {
                Console.WriteLine("{0}年 {1}円 {2} ({3})",
                                    p.PublishedYear,
                                    p.Price,
                                    p.Title,
                                    p.CategoryName);
            }
        }

        private static void Exercise1_5() {
            var publishedyear = Library.Books.Where(b => b.PublishedYear == 2016)
                                           .Join(Library.Categories,
                                           book => book.CategoryId,
                                           category => category.Id,
                                           (book, category) => category.Name)
                                           .Distinct();
            foreach (var name in publishedyear) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            var query = Library.Books.Join(Library.Categories,
                                                    book => book.CategoryId,
                                                    category => category.Id,
                                                    (book, category) => new {
                                                        book.PublishedYear,
                                                        book.Price,
                                                        book.Title,
                                                        CategoryName = category.Name,
                                                    })
                                                    .GroupBy(x => x.CategoryName)
                                                    .OrderBy(x => x.Key);

            foreach (var group in query) {
                Console.WriteLine("#{0}", group.Key);
                foreach(var item in group) {
                    Console.WriteLine(" {0}", item.Title);
                }
            }







        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
