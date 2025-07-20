bool continueProgram = true;

while (continueProgram)
{
    double[,] a = new double[3, 3];
    double[,] b = new double[3, 3];
    double[] w = new double[3];
    int[] per_gen = new int[2];
    int[] per_soc = new int[2];
    int[] gen_soc = new int[2];
    double LundaMax = 0;
    double CR = 0;
    string[] input;

    Console.Write("輸入比值 : ");

    Console.Write("請輸入「專業能力」對「通識素養」的指標比值(輸入兩個數值) : ");
    input = Console.ReadLine().Split();
    for (int i = 0; i < 2; i++)
    {
        while (!int.TryParse(input[i], out per_gen[i]))
        {
            Console.Write("Invalid input. Please enter an integer: ");
            input[i] = Console.ReadLine();
        }
    }

    Console.Write("請輸入「專業能力」對「合群性」的指標比值(輸入兩個數值) : ");
    input = Console.ReadLine().Split();
    for (int i = 0; i < 2; i++)
    {
        while (!int.TryParse(input[i], out per_soc[i]))
        {
            Console.Write("Invalid input. Please enter an integer: ");
            input[i] = Console.ReadLine();
        }
    }

    Console.Write("請輸入「通識素養」對「合群性」的指標比值(輸入兩個數值) : ");
    input = Console.ReadLine().Split();
    for (int i = 0; i < 2; i++)
    {
        while (!int.TryParse(input[i], out gen_soc[i]))
        {
            Console.Write("Invalid input. Please enter an integer: ");
            input[i] = Console.ReadLine();
        }
    }

    for (int i = 0; i < 3; i++)
    {
        a[i, i] = 1;
    }


    a[0, 1] = (double)per_gen[0] / per_gen[1];
    a[1, 0] = 1 / a[0, 1];

    a[0, 2] = (double)per_soc[0] / per_soc[1];
    a[2, 0] = 1 / a[0, 2];

    a[1, 2] = (double)gen_soc[0] / gen_soc[1];
    a[2, 1] = 1 / a[1, 2];

    Console.WriteLine("顯示比值矩陣：");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{a[i, j]:F3} ");
        }
        Console.WriteLine();
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            b[i, j] = a[i, j] / (a[0, j] + a[1, j] + a[2, j]);
        }
    }

    Console.Write("顯示指標的權重 : ");
    for (int i = 0; i < 3; i++)
    {
        w[i] = (b[i, 0] + b[i, 1] + b[i, 2]) / 3;
        Console.Write($"w{i + 1}:{w[i]:F3}\t");
    }

    Console.Write("\n顯示最大特徵值 LundaMax=");
    for (int i = 0; i < 3; i++)
    {
        LundaMax += w[i] * (a[0, i] + a[1, i] + a[2, i]);
    }
    Console.WriteLine($"{LundaMax:F3}");

    CR = (LundaMax - 3) / ((3 - 1) * 0.58);


    Console.Write($"顯示一致性比率 CR = {CR:F3}");
    if (CR < 0.1)
    {
        Console.WriteLine("。CR小於0.1，符合一致性");
    }
    else
    {
        Console.WriteLine("。CR大於0.1，不符合一致性");
    }

    bool validInput = false;
    while (!validInput)
    {
        Console.WriteLine("繼續否?(y or n)");
        switch (Console.ReadLine())
        {
            case "y":
                continueProgram = true;
                validInput = true;
                break;
            case "n":
                continueProgram = false;
                validInput = true;
                break;
            default:
                Console.WriteLine("輸入錯誤，請輸入 'y' 或 'n'");
                break;
        }
    }
}