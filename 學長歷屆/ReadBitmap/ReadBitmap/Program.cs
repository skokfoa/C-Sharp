using System;
using System.Drawing;

namespace ReadBitmap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bitmap map = new Bitmap("catgun_small.jpg");

            string chars = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'. ";

            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Color pixel = map.GetPixel(x, y);

                    int gray = (pixel.R * 299 + pixel.G * 587 + pixel.B * 114 + 500) / 1000;

                    Console.Write(chars[chars.Length - 1 - gray / chars.Length]);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
