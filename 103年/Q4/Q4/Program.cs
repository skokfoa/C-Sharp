using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private static List<Player> players = new List<Player>();
    public static void Main(string[] args)
    {
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("請選擇操作項目：");
            Console.WriteLine("\t<1>批次輸入：\n\t<2>選手查詢：\n\t<3>刪除：\n\t<4>逐筆輸入：\n\t<5>顯示所有資料：");
            Console.Write("請選擇：");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("批次輸入");
                    many_input(); 
                    break;
                case 2: 
                    Console.WriteLine("選手查詢");
                    input_chack(); 
                    break;
                case 3: 
                    Console.WriteLine("刪除");
                    delete_input(); 
                    break;
                case 4: 
                    Console.WriteLine("逐筆輸入");
                    one_input(); 
                    break;
                case 5: 
                    Console.WriteLine("顯示所有資料");
                    veiw(); 
                    break;
                default: break;
            }
            Console.WriteLine("繼續．請按1，結束．請按2：");
            if(Console.ReadLine() == "2")
            {
                exit = false;
            }
        }
    }

    public static void many_input()
    {
        Console.WriteLine("班級      學號     姓名  性別   報名項目");
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            string[] parts = input.Split(" ");
            int sex;
            if(parts.Length < 3)
            {
                return;
            }
            if (parts[3] == "男")
            {
                sex = 1;
            }
            else if (parts[3] == "女")
            {
                sex = 2;
            }
            else
            {
                sex = 0;
            }

            players.Add(new Player
            {
                Class = parts[0],
                Class_number = parts[1],
                Name = parts[2],
                Sex = sex,
                Item = parts[4]
            });
        }
    }

    public static void input_chack()
    {
        Console.WriteLine("2");
    }

    public static void delete_input()
    {
        Console.WriteLine("3");
    }

    public static void one_input()
    {
        Console.WriteLine("4");
    }

    public static void veiw()
    {
        Console.WriteLine("5");
    }
}

class Player()
{
    public string Class;
    public string Class_number;
    public string Name;
    public int Sex;
    public string Item;
}