using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入徑向距離(r) = ");

            double radius = double.Parse(Console.ReadLine().Trim());

            Console.Write("請輸入徑向多項式的次數(n) = ");

            int amount = int.Parse(Console.ReadLine().Trim());

            if (amount < 0)
            {
                Console.WriteLine("n 輸入了錯誤的負數");
                Console.ReadLine();
                return;
            }

            for (int m = 0; Math.Abs(m) <= amount; m++)
            {
                if ((amount - Math.Abs(m)) % 2 == 1)
                    continue;

                double sum = 0;

                Console.WriteLine($"計算徑向多項式(radial polynomials) ..., r = {radius}, n = {amount}, m = {m}");

                int total = (amount - m) / 2;

                for (int s = 0; s <= total; s++)
                {
                    sum += Math.Pow(-1, s) * (Mul(amount - s) / (Mul(s) * Mul(((amount - Math.Abs(m)) / 2) - s) * Mul(((amount + Math.Abs(m)) / 2) - s))) * Math.Pow(radius, amount - 2 * s);
                }

                Console.WriteLine($"所求之徑多項式為 = {sum}");
            }

            Console.WriteLine("計算完畢！");
            Console.ReadLine();
        }

        static int Mul(int level)
        {
            if(level <= 1)
            {
                return 1;
            }

            return Mul(level - 1) * level;
        }
    }
}
