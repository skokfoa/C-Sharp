using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace _109_Q2
{
    internal class Program
    {
        static void Main(string[] _)
        {
            string[] lines = File.ReadAllLines("LableData.txt");

            Console.WriteLine("開始繪製圖框！");

            foreach (string line in lines) {
                string[] args = line.Split(' ').ToArray();

                Pen pen = new Pen(Color.Red, 5);
                Bitmap bitmap = new Bitmap(args[0]);
                Graphics graphics = Graphics.FromImage(bitmap);

                for (int i = 2; i < args.Length; i += 4)
                {
                    int x = int.Parse(args[i]), y = int.Parse(args[i + 1]);

                    graphics.DrawRectangle(pen, x, y, int.Parse(args[i + 2]) - x, int.Parse(args[i + 3]) - y);
                }

                graphics.Save();
                bitmap.Save($"ImageOUT/{args[0]}");

                Console.WriteLine($"在 ./{args[0]} 圖框中加框，以相同檔名存入 ImageOUT 中");
            }

            Console.WriteLine("繪製圖框結束！");
            Console.ReadKey();
        }
    }
}
