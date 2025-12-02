using System;
using System.Linq;

namespace _107_Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            
            while(int.TryParse(Console.ReadLine(), out count))
            {
                int[] numbers = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

                int largest = 0, firstIndex = 0, lastIndex = 0;

                Loop(ref numbers, ref largest, ref firstIndex, ref lastIndex, 0);

                Console.WriteLine(largest);
                Console.WriteLine($"{firstIndex} {lastIndex}");
            }
        }

        static void Loop(ref int[] numbers, ref int largest, ref int firstIndex, ref int lastIndex, int start)
        {
            for(int i = 1; i <= numbers.Length - start; i++)
            {
                int sum = numbers.Skip(start).Take(i).Sum();

                if (sum > largest)
                {
                    largest = sum;
                    firstIndex = start;
                    lastIndex = start + i - 1;
                }
            }

            if(start < numbers.Length)
                Loop(ref numbers, ref largest, ref firstIndex, ref lastIndex, start + 1);
        }
    }
}
