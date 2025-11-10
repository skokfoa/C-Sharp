using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\宇\Desktop\C#\101年\Q6\" + textBox1.Text;

            StreamReader sr = new StreamReader(path);

            string[] input = sr.ReadToEnd()
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int[][] maze = new int[input.Length][];

            for(int i = 0; i < maze.Length; i++)
            {
                maze[i] = input[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            
            Stack<Node> value = new Stack<Node>();
            HashSet<(int, int)> visit = new HashSet<(int, int)>();
            List<(int, int)> allpath = new List<(int, int)>();

            Node start = new Node(0, 0);
            value.Push(start);

            Node ans = null;

            while(value.Count > 0)
            {
                Node now = value.Pop();
                int x = now.x;
                int y = now.y;
                if (!visit.Add((x, y)))
                {
                    continue;
                }

                allpath.Add((y, x));

                if (now.x == 7 && now.y == 7)
                {
                    ans = now;
                    break;
                }

                List<(int, int)> next = Move(maze, x, y);

                foreach(var (i , j) in next)
                {
                    Node push = new Node(i, j, now);
                    value.Push(push);
                }
            }

            textBox2.Text = string.Join(" ", allpath);
        }

        private List<(int, int)> Move(int[][] map, int x, int y)
        {
            int H = map.Length;
            int W = map[0].Length;

            var path = new List<(int, int)>();

            // 依你原本的 8 方向，並用動態邊界檢查
            if (y - 1 >= 0)
            {
                if (map[y - 1][x] == 0) path.Add((x, y - 1));                 // N
                if (x + 1 < W && map[y - 1][x + 1] == 0) path.Add((x + 1, y - 1)); // NE
            }
            if (x + 1 < W)
            {
                if (map[y][x + 1] == 0) path.Add((x + 1, y));                 // E
                if (y + 1 < H && map[y + 1][x + 1] == 0) path.Add((x + 1, y + 1)); // SE
            }
            if (y + 1 < H)
            {
                if (map[y + 1][x] == 0) path.Add((x, y + 1));                 // S
                if (x - 1 >= 0 && map[y + 1][x - 1] == 0) path.Add((x - 1, y + 1)); // SW
            }
            if (x - 1 >= 0)
            {
                if (map[y][x - 1] == 0) path.Add((x - 1, y));                 // W
                if (y - 1 >= 0 && map[y - 1][x - 1] == 0) path.Add((x - 1, y - 1)); // NW
            }

            // 想要優先某方向可調整順序或移除對角線（只要保留 N/E/S/W 四個判斷）
            path.Reverse(); // 若你要與原書相同的推疊順序，保留這行；否則可拿掉
            return path;
        }
    }

    public class Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public Node father { get; set; }

        public Node(int x, int y, Node father = null)
        {
            this.x = x;
            this.y = y;
            this.father = father;
        }
    }
}
