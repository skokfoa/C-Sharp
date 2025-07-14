using System;

namespace line
{
    class Project
    {
        public  void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] lr = new int[n, 2];

            for (int i = 0;i < n; ++i)
            {
                string[] input = Console.ReadLine().Split();
                lr[i, 0] = int.Parse(input[i]);
                lr[i, 1] = int.Parse(input[i]);
            }

            for (int i = 0; i < n; ++i)
            {
                for(int j = i;j < n; ++n)
                {
                    if (lr[i,1] >= lr[j, 0] || lr[i,0] <= lr[j, 1])
                    {
                        if (lr[i,0] >  lr[j, 0])
                        {
                            
                        }
                    }
                }
            }            




        }
    }
}