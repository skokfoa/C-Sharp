using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        uint[] target = Array.ConvertAll(input, s => uint.Parse(s, NumberStyles.HexNumber));
        for (char l1 = 'a'; l1 <= 'z'; l1++)
        {
            for (char l2 = 'a'; l2 <= 'z'; l2++)
            {
                for (char l3 = 'a'; l3 <= 'z'; l3++)
                {
                    for (char l4 = 'a'; l4 <= 'z'; l4++)
                    {
                        for (char l5 = 'a'; l5 <= 'z'; l5++)
                        {
                            Algorithm(new char[] { l1, l2, l3, l4, l5 });
                            if (Algorithm(new char[] { l1, l2, l3, l4, l5 })[0] == target[0] &&
                                Algorithm(new char[] { l1, l2, l3, l4, l5 })[1] == target[1] &&
                                Algorithm(new char[] { l1, l2, l3, l4, l5 })[2] == target[2] &&
                                Algorithm(new char[] { l1, l2, l3, l4, l5 })[3] == target[3] &&
                                Algorithm(new char[] { l1, l2, l3, l4, l5 })[4] == target[4])
                            {
                                Console.WriteLine($"{l1}{l2}{l3}{l4}{l5}");
                                return;
                            }
                        }
                    }
                }
            }
        }
        
    }

    private static uint[] Algorithm(char[] letter)
    {
        uint h0 = 0xabcd, h1 = 0xcdef, h2 = 0x2266, h3 = 0xceed, h4 = 0xaccd;
        uint a = h0, b = h1, c = h2, d = h3, e = h4;
        for(int i = 0; i< 5; i++)
        {
            int word = letter[i] - ' ';
            uint f = b + c; uint k = 0x5a82;
            uint temp = 4 * a + f + e + k + (uint)word;
            e = d; d = c; c = b; b = a; a = temp;
        }
        h0 += a; h1 += b; h2 += c; h3 += d; h4 += e;
        return new uint[] { h0, h1, h2, h3, h4 };
    }
}
