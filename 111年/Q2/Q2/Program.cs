using System;

public class Program
{
    public static void Main()
    {
        Console.Write("請輸入10位元的key: ");
        string input = Console.ReadLine();

        Console.Write("\n\n");

        int inkey = Convert.ToInt32(input,2);
        Console.WriteLine($"輸入 key: {string.Join(' ',input)} = 0x{inkey.ToString("x")}");
        string rearr1 = Rearrange10(input);
        int rearrkey1 = Convert.ToInt32(rearr1,2);
        Console.WriteLine($"重排列10: {string.Join(' ',rearr1)} = 0x{rearrkey1.ToString("x")}");
        string L1 , R1;
        L1 = RightMove(rearr1.Substring(0,5));
        R1 = RightMove(rearr1.Substring(5, 5));

        string K1 = L1 + R1;
        Console.WriteLine($"左旋轉1 : {string.Join(' ',K1)} = 0x{Convert.ToString(Convert.ToInt32(K1,2),16)}");

        string rearr2 = Rearrange8(K1);
        Console.WriteLine($"Key1輸出: {string.Join(' ',rearr2)}   = 0x{Convert.ToString(Convert.ToInt32(rearr2,2),16)}");
        L1 = RightMove(RightMove(L1));
        R1 = RightMove(RightMove(R1));

        string K2 = L1 + R1;
        Console.WriteLine($"左旋轉2 : {string.Join(' ',K2)} = 0x{Convert.ToString(Convert.ToInt32(K2,2),16)}");
        
        string rearr3 = Rearrange8(K2);
        Console.WriteLine($"Key2輸出: {string.Join(' ',rearr3)}   = 0x{Convert.ToString(Convert.ToInt32(rearr3,2),16)}");
    }

    public static string Rearrange10(string input)
    {
        string output = string.Empty;
        int[] map = { 2, 4, 1, 6, 3, 9, 0, 8, 7, 5 };
        foreach (int index in map)
        {
            output += input[index];
        }
        return output;
    }

    public static string Rearrange8(string input)
    {
        string output = string.Empty;
        int[] map = { 5, 2, 6, 3, 7, 4, 9, 8 };
        foreach (int index in map)
        {
            output += input[index];
        }
        return output;
    }

    public static string RightMove(string input)
    {
        string output = string.Empty;
        for(int i = 0;i < input.Length; i++)
        {
            int a = (i + 1) % input.Length;
            output += input[a];
        }
        return output;
    }
}   