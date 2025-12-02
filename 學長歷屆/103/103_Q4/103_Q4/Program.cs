using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _103_Q4
{
    class Data
    {
        public readonly string grade;
        public readonly string studentId;
        public readonly string name;
        public readonly string gender;
        public readonly string type;
    }

    internal class Program
    {
        static readonly List<Data> datas = new List<Data>();

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("\t<1> 批次輸入：");
                Console.WriteLine("\t<2> 選手查詢：");
                Console.WriteLine("\t<3> 刪除：");
                Console.WriteLine("\t<4> 逐筆輸入：");
                Console.WriteLine("\t<5> 顯示所有資料：");
                Console.Write("請選擇：");

                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                    Bulk();
            }
        }

        public static void Bulk()
        {
            Console.WriteLine("批次輸入：");
            Console.Write("請輸入檔名：");

            string[] lines = File.ReadAllLines(Console.ReadLine()).Skip(1).ToArray();

            foreach(var line in lines) {
                Data data = new Data
                {
                    grade
                };
            }
        }
    }
}
