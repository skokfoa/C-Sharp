using System.Runtime.CompilerServices;

public class Program
{   
    private static char[,] lastTriangle = null;
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("請選擇操作項目：");
            Console.WriteLine("\t<1>輸入二點座標(x1, y1), (x2, y2)繪一線：");
            Console.WriteLine("\t<2>輸入三點座標(x1, y1), (x2, y2), (x3, y3)繪三角形：");
            Console.WriteLine("\t<3>上題三角形水平翻轉：");
            Console.Write("請選擇：");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DrawLine();
                    break;
                case "2":
                    DrawTriangle();
                    break;
                case "3":
                    FlipTriangle();
                    break;
                default:
                    Console.WriteLine("無效選項，請重新啟動程式並選擇1、2或3。");
                    break;
            }
            Console.Write("繼續，請按1，結束，請按0：");
            string cont = Console.ReadLine();
            if (cont == "0") break;
            else if(cont != "1")
            {
                Console.WriteLine("無效選項，請重新啟動程式並選擇1或0。");
                break;
            }

        }
    }
    private static void DrawLine()
    {
        Console.Write("x1,y1,  x2,y2：");
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int x1 = input[0], y1 = input[1];
        int x2 = input[2], y2 = input[3];
        
        int height = Math.Max(y1, y2) + 1;
        int width = Math.Max(x1, x2) + 1;

        char[,] canvas = new char[height, width];

        for(int i = 0;i < height; i++)
            for(int j = 0; j < width; j++)
                canvas[i, j] = ' ';
        DrawLineOnCanvas(canvas, x1, y1, x2, y2);
        PrintCanvas(canvas);
    }

    private static void DrawTriangle()
    {
        Console.Write("x1,y1,  x2,y2,  x3,y3：");
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int x1 = input[0], y1 = input[1];
        int x2 = input[2], y2 = input[3];
        int x3 = input[4], y3 = input[5];
        int height = Math.Max(Math.Max(y1, y2), y3) + 1;
        int width = Math.Max(Math.Max(x1, x2), x3) + 1;
        char[,] canvas = new char[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                canvas[i, j] = ' ';
        DrawLineOnCanvas(canvas, x1, y1, x2, y2);
        DrawLineOnCanvas(canvas, x2, y2, x3, y3);
        DrawLineOnCanvas(canvas, x3, y3, x1, y1);
        PrintCanvas(canvas);
        lastTriangle = new char[height, width];
        for(int i = 0; i < height; i++)
            for(int j = 0; j < width; j++)
                lastTriangle[i, j] = canvas[i, j];
    }

    private static void FlipTriangle()
    {
        for(int i = 0;i < lastTriangle.GetLength(0); i++)
            for(int j = 0; j < lastTriangle.GetLength(1)/2; j++)
            {
                char temp = lastTriangle[i, j];
                lastTriangle[i, j] = lastTriangle[i, lastTriangle.GetLength(1)-1-j];
                lastTriangle[i, lastTriangle.GetLength(1)-1-j] = temp;
            }
        PrintCanvas(lastTriangle);
    }

    private static void PrintCanvas(char[,] canvas)
    {
        int height = canvas.GetLength(0);
        int width = canvas.GetLength(1);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(canvas[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static void DrawLineOnCanvas(char[,] canvas, int x1, int y1, int x2, int y2)
    {
        int height = canvas.GetLength(0);
        int width = canvas.GetLength(1);
        int dx = Math.Abs(x2 - x1), dy = -Math.Abs(y2 - y1);
        int sx = x1 < x2 ? 1 : -1, sy = y1 < y2 ? 1 : -1;
        int err = dx + dy, e2;
        while (true)
        {
            if (x1 >= 0 && x1 < width && (height - y1) >= 0 && (height - y1) < height)
                canvas[height - y1, x1] = '*';
            if (x1 == x2 && y1 == y2) break;
            e2 = 2 * err;
            if (e2 >= dy) { err += dy; x1 += sx; }
            if (e2 <= dx) { err += dx; y1 += sy; }
        }
    }
}
