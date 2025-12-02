using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace _105_Q3
{
    internal class Program
    {
        static Point[] triangles;

        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);

                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("\t<1>輸入二點座標(x1,y1), (x2,y2)繪一線：");
                Console.WriteLine("\t<2>輸入三個頂點座標(x1,y1), (x2,y2), (x3,y3)繪三角形：");
                Console.WriteLine("\t<3>上題三角形水平翻轉：");
                Console.Write("請選擇：");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("x1,y1  x2,y2: ");

                    int[] raw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                    Point first = new Point(raw[0], raw[1]), last = new Point(raw[2], raw[3]);

                    Console.Clear();

                    DrawLine(first, last);
                }

                if (choice == 2)
                {
                    Console.Write("x1,y1  x2,y2  x3,y3: ");

                    int[] raw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                    triangles = new Point[] { 
                        new Point(raw[0], raw[1]),
                        new Point(raw[2], raw[3]),
                        new Point(raw[4], raw[5]),
                    };

                    DrawLine(triangles[0], triangles[1]);
                    DrawLine(triangles[1], triangles[2]);
                    DrawLine(triangles[2], triangles[0]);
                }

                if (choice == 3)
                {
                    int min = triangles.Min(x => x.X), max = triangles.Max(x => x.X);

                    int center = min + (max - min) / 2;

                    for (int i = 0; i < 3; i++)
                        triangles[i].X = center * 2 - triangles[i].X;

                    DrawLine(triangles[0], triangles[1]);
                    DrawLine(triangles[1], triangles[2]);
                    DrawLine(triangles[2], triangles[0]);
                }

                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("繼續：請按1，結束：請按0：");

                if (Console.ReadLine() == "0")
                    break;
            }
        }

        static void DrawLine(Point first, Point last)
        {
            Draw(first.X, first.Y);
            Draw(last.X, last.Y);
            int dx = last.X - first.X;
            int dy = last.Y - first.Y;

            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            float offsetX = dx / (float)steps;
            float offsetY = dy / (float)steps;
            float currentX = first.X, currentY = first.Y;

            for (int i = 0; i < steps; i++)
            {
                Draw(currentX, currentY);

                currentX += offsetX;
                currentY += offsetY;
            }
        }

        static void Draw(float x, float y)
        {
            Console.SetCursorPosition((int)Math.Round(x), Console.WindowHeight - (int)Math.Round(y));
            Console.Write("*");
        }
    }
}
