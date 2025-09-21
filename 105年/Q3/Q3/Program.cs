using System.Runtime.CompilerServices;

public class Program
{
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
            Console.WriteLine("繼續，請按1，結束，請按0：");
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
        Console.Write("請輸入第一點座標 (x1 y1)：");
        var point1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("請輸入第二點座標 (x2 y2)：");
        var point2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int x1 = point1[0], y1 = point1[1];
        int x2 = point2[0], y2 = point2[1];
        int width = Math.Max(x1, x2) + 1;
        int height = Math.Max(y1, y2) + 1;
        char[,] canvas = new char[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                canvas[i, j] = ' ';
        // Bresenham's line algorithm
        int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
        int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
        int err = dx + dy, e2;
        while (true)
        {
            canvas[y1, x1] = '*';
            if (x1 == x2 && y1 == y2) break;
            e2 = 2 * err;
            if (e2 >= dy) { err += dy; x1 += sx; }
            if (e2 <= dx) { err += dx; y1 += sy; }
        }
        PrintCanvas(canvas);
    }

    private static void DrawTriangle()
    {
        Console.Write("請輸入第一點座標 (x1 y1)：");
        var point1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("請輸入第二點座標 (x2 y2)：");
        var point2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("請輸入第三點座標 (x3 y3)：");
        var point3 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int x1 = point1[0], y1 = point1[1];
        int x2 = point2[0], y2 = point2[1];
        int x3 = point3[0], y3 = point3[1];
        int width = Math.Max(x1, Math.Max(x2, x3)) + 1;
        int height = Math.Max(y1, Math.Max(y2, y3)) + 1;
        char[,] canvas = new char[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                canvas[i, j] = ' ';
        DrawLineOnCanvas(canvas, x1, y1, x2, y2);
        DrawLineOnCanvas(canvas, x2, y2, x3, y3);
        DrawLineOnCanvas(canvas, x3, y3, x1, y1);
        PrintCanvas(canvas);
    }

    private static void FlipTriangle()
    {
        Console.Write("請輸入第一點座標 (x1 y1)：");
        var point1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("請輸入第二點座標 (x2 y2)：");
        var point2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("請輸入第三點座標 (x3 y3)：");
        var point3 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int x1 = point1[0], y1 = point1[1];
        int x2 = point2[0], y2 = point2[1];
        int x3 = point3[0], y3 = point3[1];
        int width = Math.Max(x1, Math.Max(x2, x3)) + 1;
        int height = Math.Max(y1, Math.Max(y2, y3)) + 1;
        char[,] canvas = new char[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                canvas[i, j] = ' ';
        DrawLineOnCanvas(canvas, x1, y1, x2, y2);
        DrawLineOnCanvas(canvas, x2, y2, x3, y3);
        DrawLineOnCanvas(canvas, x3, y3, x1, y1);
        PrintCanvas(canvas);
        // Flip horizontally
        char[,] flippedCanvas = new char[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                flippedCanvas[i, j] = canvas[i, width - j - 1];
        Console.WriteLine("水平翻轉後的三角形：");
        PrintCanvas(flippedCanvas);
    }

    private static void DrawLineOnCanvas(char[,] canvas, int x1, int y1, int x2, int y2)
    {
        int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
        int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
        int err = dx + dy, e2;
        while (true)
        {
            canvas[y1, x1] = '*';
            if (x1 == x2 && y1 == y2) break;
            e2 = 2 * err;
            if (e2 >= dy) { err += dy; x1 += sx; }
            if (e2 <= dx) { err += dx; y1 += sy; }
        }
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
}
