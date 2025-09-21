public class Program
{
    static int[] top;
    static int[] mid;
    static int[] low;
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\t<1>輸入模型資料:");
            Console.WriteLine("\t<2>計算平台相似度:");
            Console.WriteLine("\t<3>顯示各資料相似度:");
            Console.Write("請選擇:");

            string choose = Console.ReadLine();

            if (choose != "1" && choose != "2" && choose != "3")
            {
                Console.WriteLine("輸入錯誤，請重新輸入");
                return;
            }

            switch (choose)
            {
                case "1":
                    InputModelData();
                    break;
                case "2":
                    CalculateSimilarity();
                    break;
                case "3":
                    DisplaySimilarities();
                    break;
            }
            Console.Write("繼續：請輸1，結束：請輸0：");
            string cont = Console.ReadLine();
            if (cont == "0")
                break;
            else if (cont != "1")
            {
                Console.WriteLine("輸入錯誤，請重新輸入");
                break;
            }
        }
    }

    static void InputModelData()
    {
        Console.Write("輸入模型資料，總比數為：");
        string input = Console.ReadLine();
        int count = new int();

        if (!int.TryParse(input, out count) || count <= 0)
        {
            Console.Write("輸入錯誤，請重新輸入");
            return;
        }

        top = new int[count];
        mid = new int[count];
        low = new int[count];

        Console.Write("\n    序列< x軸>：");

        for (int i = 0; i < count; i++)
        {
            Console.Write($" {i,2}");
        }
        Console.Write("\n數值串列<上限>： ");
        string[] read = Console.ReadLine().Split(' ');
        for (int i = 0; i < count; i++)
        {
            if (!int.TryParse(read[i], out top[i]) || top[i] < 0)
            {
                Console.Write("輸入錯誤，請重新輸入");
                return;
            }
        }

        Console.Write("數值串列<中心>： ");
        read = Console.ReadLine().Split(' ');
        for (int i = 0; i < count; i++)
        {
            if (!int.TryParse(read[i], out mid[i]) || mid[i] < 0 || mid[i] > top[i])
            {
                Console.Write("輸入錯誤，請重新輸入");
                return;
            }
        }

        Console.Write("數值串列<下限>： ");
        read = Console.ReadLine().Split(' ');
        for (int i = 0; i < count; i++)
        {
            if (!int.TryParse(read[i], out low[i]) || low[i] < 0 || low[i] > mid[i])
            {
                Console.Write("輸入錯誤，請重新輸入");
                return;
            }
        }

    }

    static void CalculateSimilarity()
    {
        Console.WriteLine("計算平台相似度功能尚未實作");
    }

    static void DisplaySimilarities()
    {
        Console.WriteLine("顯示各資料相似度功能尚未實作");
    }
}