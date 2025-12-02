using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("輸入比值：");
            Console.Write("請輸入「專業能力」對「通識素養」的指標比值<輸入2個數值>：");

            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x.Trim())).ToArray();
        }
    }
}
