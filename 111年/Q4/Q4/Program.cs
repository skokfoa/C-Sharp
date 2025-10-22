using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

public class Program
{
    private static int[] line = new int[5];
    private static int right = 0, left = -1,num = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("南港公司生產排程系統");
        while (true)
        {
            Console.WriteLine("請選擇: ");
            Console.WriteLine("   1.從生產線左邊加入物件");
            Console.WriteLine("   2.從生產線左邊移除物件");
            Console.WriteLine("   3.從生產線右邊加入物件");
            Console.WriteLine("   4.從生產線右邊移除物件");
            Console.WriteLine("   5.生產排程結束");
            Console.Write("? ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddLeft();
                    break;
                case "2":
                    RemoveLeft();
                    break;
                case "3":
                    AddRight();
                    break;
                case "4":
                    RemoveRight();
                    break;
                case "5":
                    Console.WriteLine("生產排程結束!");
                    return;
                default:
                    Console.WriteLine("輸入錯誤!  請重新輸入!\n");
                    break;
            }
        }
    }

    public static void AddLeft()
    {
        num++;
        Console.Write("請輸入物件編號: ");
        int item = int.Parse(Console.ReadLine());

        if (num > line.Length)
        {
            num--;
            Console.WriteLine("生產線已滿!" +
                $"\n生產線線上有{num}物件");
            return;
        }

        left = (left + 1) % 5;

        Console.WriteLine("從左邊加入:");
        Console.WriteLine($"左邊作業員編號：{left}");
        Console.WriteLine($"右邊作業員編號：{right}");

        line[left] = item;

        Console.WriteLine($"加入物件：{item}");
        Console.WriteLine($"生產線線上有{num}物件\n");
    }

    public static void RemoveLeft()
    {
        num--;

        if (num < 0)
        {
            num++;
            Console.WriteLine("生產線空的!" +
                $"\n生產線線上有{num}物件\n");
            return;
        }

        int item = line[left];
        line[left] = new int();

        left = (left + 4) % 5;

        Console.WriteLine("從做邊刪除：");
        Console.WriteLine($"左邊作業員編號：{left}");
        Console.WriteLine($"右邊作業員編號：{right}");
        Console.WriteLine($"\n刪除物件編號：{item}");
        Console.WriteLine($"生產線線上有{num}物件\n");
    }

    public static void AddRight()
    {
        num++;
        Console.Write("請輸入物件編號: ");
        int item = int.Parse(Console.ReadLine());

        if (num > line.Length)
        {
            num--;
            Console.WriteLine("生產線已滿!" +
                $"\n生產線線上有{num}物件");
            return;
        }

        right = (right + 4) % 5;

        Console.WriteLine("從左邊加入:");
        Console.WriteLine($"左邊作業員編號：{left}");
        Console.WriteLine($"右邊作業員編號：{right}");

        line[right] = item;

        Console.WriteLine($"加入物件：{item}");
        Console.WriteLine($"生產線線上有{num}物件\n");
    }

    public static void RemoveRight()
    {
        num--;

        if (num < 0)
        {
            num++;
            Console.WriteLine("生產線空的!" +
                $"\n生產線線上有{num}物件\n");
            return;
        }

        int item = line[right];
        line[right] = new int();

        right = (right + 1) % 5;

        Console.WriteLine("從做邊刪除：");
        Console.WriteLine($"左邊作業員編號：{left}");
        Console.WriteLine($"右邊作業員編號：{right}");
        Console.WriteLine($"\n刪除物件編號：{item}");
        Console.WriteLine($"生產線線上有{num}物件\n");
    }
}