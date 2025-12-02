using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("請輸入密碼：");
        string passward = Console.ReadLine();

        Console.WriteLine();

        int plen = passward.Length;

        int digit   = new int();
        int cupper  = new int();
        int clower  = new int();
        int cop     = new int();

        char[] op = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '=' };

        for(int i = 0; i < plen; i++)
        {
            if (char.IsDigit(passward[i])) digit++;
            if(char.IsUpper(passward[i])) cupper++;
            if(char.IsLower(passward[i])) clower++;
            for(int j = 0; j < op.Length; j++)
            {
                if (passward[i] == op[j]) cop++;
            }
        }

        Console.WriteLine($"密碼長度：{plen}");
        Console.WriteLine($"大寫英文字母長度：{cupper}");
        Console.WriteLine($"小寫英文字母長度：{clower}");
        Console.WriteLine($"數字長度：{digit}");
        Console.WriteLine($"符號長度：{cop}");

        int count = new int();

        if(!(plen >= 8 && plen <= 128))
        {
            Console.WriteLine("不符合密碼規則");
            return;
        }

        if (cupper > 0) count++;
        if (clower > 0) count++;
        if (digit > 0) count++;
        if (cop > 0) count++;

        if(count >= 3)
        {
            Console.WriteLine("符合密碼規則");
        }
        else
        {
            Console.WriteLine("不符合密碼規則");
        }
    }
}