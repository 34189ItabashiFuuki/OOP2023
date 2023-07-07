using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            //var dateTime = new DateTime(2019, 1, 15, 19, 48, 32);
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var str = string.Format("{0}/{1}/{2} {3}:{4}",dateTime.Year,dateTime.Month,dateTime.Day,dateTime.Hour,dateTime.Minute);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            var str = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var date = new DateTime( dateTime.Year, dateTime.Month, dateTime.Day);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            var str = date.ToString("ggyy年 M月d日"+ "(" +  dayOfWeek + ")",culture);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            

        }
    }
}
