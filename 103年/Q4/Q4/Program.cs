using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
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
            input = input.Replace('\u3000', ' ');
            string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
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
        Console.Write("請輸入班級、學號、姓名：");
        string[] input = Console.ReadLine().Split();

        byte count = 0;
        for (int i = 0; i < players.Count; i++)
        {
            if (input[0] == players[i].Class && input[1] == players[i].Class_number && input[2] == players[i].Name)
            {
                string[] sex = new string[] { "未知", "男", "女" };
                Console.WriteLine($"{count + 1}. {players[i].Class} {players[i].Class_number} {players[i].Name} {sex[players[i].Sex]} {players[i].Item}");
                count++;
            }
        }
    }

    public static void delete_input()
    {
        Console.Write("請輸入班級、學號、姓名及報名項目：");
        string[] input = Console.ReadLine().Split();

        for (int i = 0; i < players.Count; i++)
        {
            if (input[0] == players[i].Class && input[1] == players[i].Class_number && input[2] == players[i].Name && input[3] == players[i].Item)
            {
                string[] sex = new string[] { "未知", "男", "女" };
                Console.WriteLine($"被刪除選手資料：{players[i].Class} {players[i].Class_number} {players[i].Name} {sex[players[i].Sex]} {players[i].Item}");
                players.RemoveAt(i);
                return;
            }
        }
    }

    public static void one_input()
    {
        Console.Write("請輸入班級、學號、姓名及性別：");
        string[] input = Console.ReadLine().Split();
        string[] item = new string[] {"大隊接力",
                                      "一顆球的距離",
                                      "天旋地轉",
                                      "滾大球袋鼠跳",
                                      "攜手同心",
                                      "100 公尺",
                                      "400 公尺接力",
                                      "800 公尺",
                                      "跳高"};
        char[] item_alf = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
        Console.WriteLine("報名項目：");
        for (int i = 0; i < item.Length; i++)
        {
            Console.WriteLine($"{item_alf[i]}：{item[i]}");
        }
        Console.Write("請選擇：");
        string item_input = Console.ReadLine();
        int sex;
        if (input.Length < 3)
        {
            return;
        }
        if (input[3] == "男")
        {
            sex = 1;
        }
        else if (input[3] == "女")
        {
            sex = 2;
        }
        else
        {
            sex = 0;
        }
        for (int i = 0; i < item_alf.Length; i++)
        {
            if (item_input == item_alf[i].ToString())
            {
                players.Add(new Player
                {
                    Class = input[0],
                    Class_number = input[1],
                    Name = input[2],
                    Sex = sex,
                    Item = item[i]
                });
                break;
            }
        }
    }

    public static void veiw()
    {
        string[] item = new string[] {"大隊接力",
                                      "一顆球的距離",
                                      "天旋地轉",
                                      "滾大球袋鼠跳",
                                      "攜手同心",
                                      "100 公尺",
                                      "400 公尺接力",
                                      "800 公尺",
                                      "跳高"};
        char[] item_alf = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
        Console.WriteLine("報名項目：");
        for (int i = 0; i < item.Length; i++)
        {
            Console.WriteLine($"{item_alf[i]}：{item[i]}");
        }
        Console.WriteLine("班級      學號     姓名  性別   報名項目");
        string[] sex = new string[] { "未知", "男", "女" };
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine($"{players[i].Class}  {players[i].Class_number} {players[i].Name}   {sex[players[i].Sex]}    {players[i].Item}");
        }
    }
}

class Player
{
    public string Class;
    public string Class_number;
    public string Name;
    public int Sex;
    public string Item;
}