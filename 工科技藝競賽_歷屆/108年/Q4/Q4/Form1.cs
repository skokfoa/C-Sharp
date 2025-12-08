using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public int[,] state;
        public int dot;

        public Form1()
        {
            InitializeComponent();
            
            dot = 0;
            state = new int[11, 11];

            using (Graphics g = panel1.CreateGraphics())
            {
                init(g);
            }
        }

        private void init(Graphics g)
        {
            Pen p = new Pen(Color.Black, 1);
            g.Clear(SystemColors.Control);

            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(p, 10, 10 + i * 40, 420 - 10, 10 + i * 40);
                g.DrawLine(p, 10 + i * 40, 10, 10 + i * 40, 420 - 10);
            }
        }

        private void drawstart(Point a, Graphics g)
        {
            Brush clean = new SolidBrush(SystemColors.Control);
            Brush b = new SolidBrush(Color.Blue);
            Brush w = new SolidBrush(Color.White);
            int gap = 20;

            g.FillRectangle(clean, a.X - gap / 2, a.Y - gap / 2, gap, gap);
            g.FillEllipse(b, a.X - gap / 2,a.Y - gap / 2, gap, gap);
            g.FillEllipse(w, a.X - (gap - 2) / 2, a.Y - (gap - 2) / 2, gap - 2, gap - 2);
        }

        private void drawend(Point a, Graphics g) 
        {
            
            Brush clean = new SolidBrush(SystemColors.Control);
            Brush r = new SolidBrush(Color.Red);
            int gap = 20;

            g.FillRectangle(clean, a.X - gap / 2, a.Y - gap / 2, gap, gap);
            g.FillRectangle(r, a.X - gap / 2, a.Y - gap / 2, gap, gap);
            g.FillRectangle(clean, a.X - gap / 2 + 1, a.Y - gap / 2 + 1, gap - 2, gap - 2);
        }

        private void drawblock(Point a, Graphics g)
        {
            Brush clean = new SolidBrush(SystemColors.Control);
            Brush b = new SolidBrush(Color.Black);
            int gap = 20;

            g.FillRectangle(clean, a.X - gap / 2, a.Y - gap / 2, gap, gap);
            g.FillEllipse(b, a.X - gap / 2, a.Y - gap / 2, gap, gap);
        }

        private void drawclear(Point a)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                Brush clean = new SolidBrush(SystemColors.Control);
                Pen p = new Pen (Color.Black, 1);

                int gap = 20;
                g.FillRectangle(clean, a.X - gap / 2, a.Y - gap / 2, gap, gap);
                g.DrawLine(p, a.X - gap, a.Y, a.X + gap, a.Y);
                g.DrawLine(p, a.X, a.Y - gap, a.X, a.Y + gap);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point now = panel1.PointToClient(Cursor.Position);
            Graphics g = panel1.CreateGraphics();

            int x = now.X;
            int y = now.Y;

            x = ((x) / 40) * 40 + 10;
            y = ((y) / 40) * 40 + 10;

            now = new Point(x, y);

            int statex = (now.X - 10) / 40;
            int statey = (now.Y - 10) / 40;

            if (dot == 0)
            {
                switch(state[statex, statey])
                {
                    case 1:
                        dot = 1;
                        break;
                    case 2:
                        dot = 2;
                        break;
                    case -1:
                        dot = -1;
                        break;
                }
                state[statex, statey] = 0;
                if (dot != 0)
                {
                    drawclear(now);
                }
                
                return;
            }
            else
            {
                if (state[statex, statey] != 0) return;

                switch (dot)
                {
                    case 1:
                        drawstart(now, g);
                        state[statex, statey] = 1;
                        dot = 0;
                        break;
                    case 2:
                        drawend(now, g);
                        state[statex, statey] = 2;
                        dot = 0;
                        break;
                    case -1:
                        drawblock(now, g);
                        state[statex, statey] = -1;
                        dot = 0;
                        break;
                    default:
                        dot = 0;
                        break;
                }
            }

            if (comboBox1.SelectedIndex == 0)
                BFS();
            else if (comboBox1.SelectedIndex == 1)
                DFS();
            else if (comboBox1.SelectedIndex == 2)
                Astar();
            else
                MessageBox.Show("請選擇演算法");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            state = new int[11, 11];

            Random rand = new Random();

            Point start = new Point();
            Point end = new Point();
            HashSet<Point> block = new HashSet<Point>();

            start = new Point(rand.Next(0, 11) * 40 + 10, rand.Next(0, 11) * 40 + 10);
            end   = new Point(rand.Next(0, 11) * 40 + 10, rand.Next(0, 11) * 40 + 10);

            while (block.Count < 32)
            {
                int x = rand.Next(0, 11) * 40 + 10;
                int y = rand.Next(0, 11) * 40 + 10;

                if (x == start.X && y == start.Y) continue;
                if (x == end.X && y == end.Y)     continue;

                block.Add(new Point(x, y));
            }

            using (Graphics g = panel1.CreateGraphics())
            {
                init(g);
                drawstart(start, g);
                drawend(end, g);

                foreach (Point b in block)
                {
                    drawblock(b, g);
                }
            }

            start = new Point((start.X - 10) / 40, (start.Y - 10) / 40);
            end = new Point((end.X - 10) / 40, (end.Y - 10) / 40);

            block = new HashSet<Point>(block.Select(p => new Point((p.X - 10) / 40, (p.Y - 10) / 40)));

            state[start.X, start.Y] = 1;
            state[end.X, end.Y] = 2;
            foreach (Point b in block)
            {
                state[b.X, b.Y] = -1;
            }

            if (comboBox1.SelectedIndex == 0)
                BFS();
            else if (comboBox1.SelectedIndex == 1)
                DFS();
            else if (comboBox1.SelectedIndex == 2)
                Astar();
            else
                MessageBox.Show("請選擇演算法");
        }

        private void BFS()
        {
            bool ifstart = false;
            for(int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if(state[i, j] != 0)
                    {
                        ifstart = true;
                        break;
                    }
                }
            }

            if (!ifstart) return;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            label5.Text = "";
            Node start = new Node(new Point());
            Point end = new Point();

            Node result = new Node(new Point());

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (state[i, j] == 1)
                    {
                        start = new Node(new Point(i, j));
                    }
                    else if (state[i, j] == 2)
                    {
                        end = new Point(i, j);
                    }
                }
            }

            Queue<Node> q = new Queue<Node>();
            HashSet<Point> visited = new HashSet<Point>();
            
            q.Enqueue(start);
            visited.Add(start.p);

            while(q.Count > 0)
            {
                Node now = q.Dequeue();

                if (now.p == end) 
                {
                    result = now;
                    break; 
                }

                List<Node> move = new List<Node>();
                move = Move(now);

                foreach (Node dir in move)
                {
                    Point nextp = dir.p;
                    if (visited.Contains(nextp))
                        continue;
                    q.Enqueue(dir);
                    visited.Add(nextp);
                }
            }

            if (result.p != end)
            {
                label5.Text = "規劃路線失敗";
                return;
            }

            label5.Text = "規劃路線成功";

            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(SystemColors.Control);
                init(g);

                for(int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (state[i, j] == 1)
                            drawstart(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == 2)
                            drawend(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == -1)
                            drawblock(new Point(i * 40 + 10, j * 40 + 10), g);
                    }
                }

                Pen p = new Pen(Color.Blue, 3);
                
                List<Point> path = new List<Point>();
                path = this.Path(result);

                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Point a = new Point(path[i].X * 40 + 10, path[i].Y * 40 + 10);
                        Point b = new Point(path[i + 1].X * 40 + 10, path[i + 1].Y * 40 + 10);
                        g.DrawLine(p, a, b);
                    }
                }
            }

            sw.Stop();
            label6.Text = $"{sw.ElapsedMilliseconds}ms";
        }

        private void DFS()
        {
            bool ifstart = false;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (state[i, j] != 0)
                    {
                        ifstart = true;
                        break;
                    }
                }
            }

            if (!ifstart) return;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            label5.Text = "";
            Node start = new Node(new Point());
            Point end = new Point();

            Node result = new Node(new Point());

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (state[i, j] == 1)
                    {
                        start = new Node(new Point(i, j));
                    }
                    else if (state[i, j] == 2)
                    {
                        end = new Point(i, j);
                    }
                }
            }

            Stack<Node> q = new Stack<Node>();
            HashSet<Point> visited = new HashSet<Point>();

            q.Push(start);
            visited.Add(start.p);

            while (q.Count > 0)
            {
                Node now = q.Pop();

                if (now.p == end)
                {
                    result = now;
                    break;
                }

                List<Node> move = new List<Node>();
                move = Move(now);

                foreach (Node dir in move)
                {
                    Point nextp = dir.p;
                    if (visited.Contains(nextp))
                        continue;
                    q.Push(dir);
                    visited.Add(nextp);
                }
            }

            if (result.p != end)
            {
                label5.Text = "規劃路線失敗";
                return;
            }

            label5.Text = "規劃路線成功";

            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(SystemColors.Control);
                init(g);

                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (state[i, j] == 1)
                            drawstart(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == 2)
                            drawend(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == -1)
                            drawblock(new Point(i * 40 + 10, j * 40 + 10), g);
                    }
                }

                Pen p = new Pen(Color.Blue, 3);

                List<Point> path = new List<Point>();
                path = this.Path(result);

                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Point a = new Point(path[i].X * 40 + 10, path[i].Y * 40 + 10);
                        Point b = new Point(path[i + 1].X * 40 + 10, path[i + 1].Y * 40 + 10);
                        g.DrawLine(p, a, b);
                    }
                }
            }

            sw.Stop();
            label6.Text = $"{sw.ElapsedMilliseconds}ms";
        }

        private void Astar()
        {
            // 確認有起點/終點資料
            bool ifstart = false;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (state[i, j] != 0)
                    {
                        ifstart = true;
                        break;
                    }
                }
                if (ifstart) break;
            }

            if (!ifstart) return;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            label5.Text = "";

            // 找起點跟終點
            Point startP = new Point();
            Point end = new Point();

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (state[i, j] == 1)
                    {
                        startP = new Point(i, j);
                    }
                    else if (state[i, j] == 2)
                    {
                        end = new Point(i, j);
                    }
                }
            }

            

            ANode start = new ANode(startP, null, 0, 0);
            start.fcost = Heuristic(start.p, end);

            List<ANode> open = new List<ANode>();      // 開放列表
            HashSet<Point> closed = new HashSet<Point>(); // 關閉集合

            open.Add(start);

            ANode result = null;

            while (open.Count > 0)
            {
                // 1. 取出 fcost 最小的點當前擴展
                ANode current = open[0];
                foreach (ANode node in open)
                {
                    if (node.fcost < current.fcost ||
                        (node.fcost == current.fcost && node.cost < current.cost))
                    {
                        current = node;
                    }
                }

                // 如果已經到終點，就結束
                if (current.p == end)
                {
                    result = current;
                    break;
                }

                open.Remove(current);
                closed.Add(current.p);

                int x = current.p.X;
                int y = current.p.Y;

                // 四個方向
                int[,] dirs = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

                for (int k = 0; k < 4; k++)
                {
                    int nx = x + dirs[k, 0];
                    int ny = y + dirs[k, 1];

                    // 邊界
                    if (nx < 0 || nx >= 11 || ny < 0 || ny >= 11) continue;
                    // 障礙物
                    if (state[nx, ny] == -1) continue;

                    Point np = new Point(nx, ny);

                    // 已經在 closed 裡就不用再看
                    if (closed.Contains(np)) continue;

                    int newCost = current.cost + 1; // 每一步成本 = 1

                    // 看看 open 裡有沒有這個點
                    ANode exist = open.FirstOrDefault(n => n.p == np);

                    if (exist != null)
                    {
                        // 如果新的成本比較小，就更新它（更好的路徑）
                        if (newCost < exist.cost)
                        {
                            exist.cost = newCost;
                            exist.father = current;
                            exist.fcost = newCost + Heuristic(np, end);
                        }
                    }
                    else
                    {
                        // 新節點
                        ANode next = new ANode(np, current, newCost, newCost + Heuristic(np, end));
                        open.Add(next);
                    }
                }
            }

            if (result == null)
            {
                sw.Stop();
                label5.Text = "規劃路線失敗";
                label6.Text = $"{sw.ElapsedMilliseconds}ms";
                return;
            }

            label5.Text = "規劃路線成功";

            // 畫圖
            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(SystemColors.Control);
                init(g);

                // 先把所有點畫回去
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (state[i, j] == 1)
                            drawstart(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == 2)
                            drawend(new Point(i * 40 + 10, j * 40 + 10), g);
                        else if (state[i, j] == -1)
                            drawblock(new Point(i * 40 + 10, j * 40 + 10), g);
                    }
                }

                Pen p = new Pen(Color.Blue, 3);

                List<Point> path = PathA(result);

                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Point a = new Point(path[i].X * 40 + 10, path[i].Y * 40 + 10);
                        Point b = new Point(path[i + 1].X * 40 + 10, path[i + 1].Y * 40 + 10);
                        g.DrawLine(p, a, b);
                    }
                }
            }

            sw.Stop();
            label6.Text = $"{sw.ElapsedMilliseconds}ms";
        }//chatgpt

        private List<Node> Move(Node now)
        {
            List<Node> moves = new List<Node>();

            int x = now.p.X;
            int y = now.p.Y;

            if (x + 1 < 11 && state[x + 1, y] != -1)
            {
                moves.Add(new Node(new Point(x + 1, y),now));
            }

            if (x - 1 >= 0 && state[x - 1, y] != -1)
            {
                moves.Add(new Node(new Point(x - 1, y), now));
            }

            if (y + 1 < 11 && state[x, y + 1] != -1)
            {
                moves.Add(new Node(new Point(x, y + 1), now));
            }

            if (y - 1 >= 0 && state[x, y - 1] != -1)
            {
                moves.Add(new Node(new Point(x, y - 1), now));
            }

            return moves;
        }

        private List<Point> Path(Node current)
        {
            List<Point> total_path = new List<Point>();
            total_path.Add(current.p);
            while (current.father != null)
            {
                current = current.father;
                total_path.Add(current.p);
            }
            total_path.Reverse();
            return total_path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            init(g);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                BFS();
            else if (comboBox1.SelectedIndex == 1)
                DFS();
            else if (comboBox1.SelectedIndex == 2)
                Astar();
            else
                MessageBox.Show("請選擇演算法");
        }

        private int Heuristic(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y); //chatgpt

        private List<Point> PathA(ANode current)
        {
            List<Point> total_path = new List<Point>();
            total_path.Add(current.p);
            while (current.father != null)
            {
                current = current.father;
                total_path.Add(current.p);
            }
            total_path.Reverse();
            return total_path;
        } //chatgpt
    }

    class ANode
    {
        public Point p { get; set; }
        public ANode father { get; set; }
        public int cost { get; set; }
        public int fcost { get; set; }

        public ANode(Point p, ANode father, int cost, int fcost)
        {
            this.p = p;
            this.father = father;
            this.cost = cost;
            this.fcost = fcost;
        }
    }

    class Node
    {
        public Point p { get; set; }
        public Node father { get; set; }
        
        public Node(Point p, Node father = null)
        {
            this.p = p;
            this.father = father;
        }
    }
}