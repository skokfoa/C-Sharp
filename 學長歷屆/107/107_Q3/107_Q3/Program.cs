using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _107_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入密碼：");

            string password = Console.ReadLine();

            bool valid = password.Length >= 8 && password.Length <= 128;
            int check = 0;

            Console.WriteLine($"密碼長度：{password.Length}");

            int upper = password.Count(c => char.IsUpper(c));

            if (upper > 0)
                check++;

            Console.WriteLine($"大寫英文字母：{upper}");

            int lower = password.Count(c => char.IsLower(c));

            if (lower > 0)
                check++;

            Console.WriteLine($"小寫英文字母：{lower}");

            int number = password.Count(c => char.IsNumber(c));

            if (number > 0)
                check++;

            Console.WriteLine($"數字：{number}");

            int symbol = password.Count(c => char.IsSymbol(c));

            if (symbol > 0)
                check++;

            Console.WriteLine($"符號：{symbol}");

            if (check < 3)
                valid = false;

            string no = valid ? "" : "不";

            Console.WriteLine($"{no}符合密碼規則");
            Console.ReadLine();
        }
    }
}
