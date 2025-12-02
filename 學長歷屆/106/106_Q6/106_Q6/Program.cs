using System;
using System.Linq;
using System.Numerics;

namespace _106_Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (Input(out int number))
            {
                // BigInteger is epic!!!!
                BigInteger mul = new BigInteger(1);

                for (int i = 2; i <= number; i++)
                    mul *= i;

                Console.WriteLine(mul);
                Console.WriteLine(mul.ToString().Select(x => x - '0').Sum());

                int sum = 0;

                while (mul > 1)
                {
                    int index = 2;
                    
                    while(true)
                    {
                        if(mul % index == 0)
                        {
                            sum++;
                            mul /= index;
                            break;
                        }

                        index++;
                    }
                }

                Console.WriteLine(sum);
            }
        }

        public static bool Input(out int number)
        {
            Console.Write("請輸入N：");

            return int.TryParse(Console.ReadLine(), out number);
        }
    }
}
