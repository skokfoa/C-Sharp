using System;
using System.Drawing;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        int count = 0;
        Console.Write("輸入一個二維陣列: ");
        string input = Console.ReadLine();

        string patten = @"\[[\d, ]+\]";
        string patten2 = @"\d";

        MatchCollection matches = Regex.Matches(input, patten);

        Console.WriteLine("數字地圖:");
        foreach (Match match in matches)
        {
            MatchCollection matches2 = Regex.Matches(match.Value, patten2);
            Console.WriteLine(match.Value);
        }
    }
}