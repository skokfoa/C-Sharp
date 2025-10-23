using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Progrem
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Console.WriteLine("你為O、電腦為X\n" +
                          "位置對應數字鍵盤");

        int[,] game = new int[3, 3];
        game = start();

        while (true)
        {
            
            printGmae(game);
            Console.Write("請輸入1~9(按0鍵結束)：");
            int you = int.Parse(Console.ReadLine()) - 1;

            if (you == -1) return;
            game[2 - you / 3, you % 3] = 1;

            if(printwin(ref game)) continue;

            while (win(game) != 5)
            {
                int computerx = rand.Next(3);
                int computery = rand.Next(3);
                if (game[computerx, computery] == 0)
                {
                    game[computerx, computery] = 2;
                    break;
                }
            }

            if (printwin(ref game)) continue;
        }
    }

    private static int[,] start()
    {
        int[,] ints = new int[3, 3];
        for(int i = 0;i < 3; i++)
        {
            ints[i, 0] = 0;
            ints[i, 1] = 0;
            ints[i, 2] = 0;
        }
        return ints;
    }

    private static void printGmae(int[,] game)
    {
        string[][] output = new string[3][];
        for(int i = 0;i < 3; i++)
        {
            output[i] = new string[3];
            for(int j = 0;j < 3; j++)
            {
                switch(game[i,j])
                {
                    case 0:
                        output[i][j] = "口";
                        break;
                    case 1:
                        output[i][j] = "Ｏ";
                        break;
                    case 2:
                        output[i][j] = "Ｘ";
                        break;
                }
            }
        }

        for(int i = 0; i  < 3; i++)
        {
            Console.WriteLine(string.Join("", output[i]));
        }
    }

    private static byte win(int[,] game)
    {
        byte youWin = 1;
        byte comWin = 2;
        byte tie = 5;

        for(int i = 0;i < 3; i++)
        {
            if(game[i,0] == game[i,1] && game[i,1] == game[i,2] && game[i,0] == game[i, 2])
            {
                if (game[i, 0] != 0 && game[i, 1] != 0 && game[i, 2] != 0)
                {
                    if (game[i,0] == 1) return youWin;
                    if (game[i,0] == 2) return comWin;
                }
            }

            if (game[0, i] == game[1, i] && game[1, i] == game[2, i] && game[2, i] == game[0, i])
            {
                if (game[0, i] != 0 && game[1, i] != 0 && game[2, i] != 0)
                {
                    if (game[i, 0] == 1) return youWin;
                    if (game[i, 0] == 2) return comWin;
                }
            }
        }

        if (game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2] && game[2, 2] == game[0, 0])
        {
            if (game[0, 0] == 1) return youWin;
            if (game[0, 0] == 2) return comWin;
        }

        if (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0] && game[2, 0] == game[0, 2])
        {
            if (game[1, 1] == 1) return youWin;
            if (game[1, 1] == 2) return comWin;
        }

        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (game[i, j] == 0) count++;
            }
        }

        if (count == 0) return tie;

        return 0;
    } 

    private static bool printwin(ref int[,] game)
    {
        switch (win(game))
        {
            case 5:
                printGmae(game);
                Console.WriteLine("雙方平手　再來一盤\n");
                game = start();
                return true;
                break;
            case 1:
                printGmae(game);
                Console.WriteLine("你O方獲勝　再來一盤\n");
                game = start();
                return true;
                break;
            case 2:
                printGmae(game);
                Console.WriteLine("電腦X方獲勝　再來一盤\n");
                game = start();
                return true;
                break;
        }
        return false;
    }
}