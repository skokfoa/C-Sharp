using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        // ====== 狀態與設定 ======
        private const int N = 11;
        private int between = 40;                 // 格與格間距
        private Point[,] points = new Point[N, N];
        private CellType[,] grid = new CellType[N, N]; // 格點狀態
        private byte paint = 0;                   // 2=Obstacle, 3=Start, 4=Target
        private readonly Random rand = new Random();

        private (int x, int y) start = (-1, -1);
        private (int x, int y) target = (-1, -1);
        private readonly List<Point> path = new List<Point>(); // 以格點中心為座標

        private enum CellType { Empty, Obstacle, Start, Target }

        public Form1()
        {
            InitializeComponent();

            // panel1 開雙緩衝，減少閃爍
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .SetValue(panel1, true);

            // 初始清空
            ClearGrid();
            BuildPoints();
        }

        // ====== 事件 ======

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 畫格線
            using (var pen = new Pen(Color.Black))
            {
                for (int i = 0; i < N; i++)
                {
                    g.DrawLine(pen, points[0, i], points[N - 1, i]);
                    g.DrawLine(pen, points[i, 0], points[i, N - 1]);
                }
            }

            // 畫每個格點的圖示
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    switch (grid[x, y])
                    {
                        case CellType.Obstacle: DrawBlock(g, points[x, y]); break;
                        case CellType.Start: DrawStart(g, points[x, y]); break;
                        case CellType.Target: DrawEnd(g, points[x, y]); break;
                    }
                }
            }

            // 畫最短路徑（藍線）
            if (path.Count > 1)
            {
                using var penPath = new Pen(Color.Blue, 3);
                for (int i = 1; i < path.Count; i++)
                    g.DrawLine(penPath, path[i - 1], path[i]);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // 找到點擊到的格點（以 between/2 為捕捉區）
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    if (Math.Abs(e.X - points[x, y].X) < between / 2 &&
                        Math.Abs(e.Y - points[x, y].Y) < between / 2)
                    {
                        switch (paint)
                        {
                            case 2: // Obstacle：切換空 <-> 障礙（但不能蓋 S/T）
                                if (grid[x, y] == CellType.Empty) grid[x, y] = CellType.Obstacle;
                                else if (grid[x, y] == CellType.Obstacle) grid[x, y] = CellType.Empty;
                                break;

                            case 3: // Start：全域只允許一個
                                // 清掉舊的
                                if (start.x >= 0) grid[start.x, start.y] = CellType.Empty;
                                // 不能放在 Target / Obstacle 上
                                if (grid[x, y] == CellType.Target || grid[x, y] == CellType.Obstacle) break;
                                grid[x, y] = CellType.Start;
                                start = (x, y);
                                break;

                            case 4: // Target：全域只允許一個
                                if (target.x >= 0) grid[target.x, target.y] = CellType.Empty;
                                if (grid[x, y] == CellType.Start || grid[x, y] == CellType.Obstacle) break;
                                grid[x, y] = CellType.Target;
                                target = (x, y);
                                break;
                        }

                        ReplanPath();          // 每次變更後重新規劃
                        panel1.Invalidate();   // 觸發重繪
                        return;
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var center = new Point(panel2.Width / 2, panel2.Height / 2);
            DrawBlock(e.Graphics, center);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            var center = new Point(panel3.Width / 2, panel3.Height / 2);
            DrawStart(e.Graphics, center);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            var center = new Point(panel4.Width / 2, panel4.Height / 2);
            DrawEnd(e.Graphics, center);
        }

        private void label2_Click(object sender, EventArgs e) => paint = 2; // Obstacle
        private void label3_Click(object sender, EventArgs e) => paint = 3; // Start
        private void label4_Click(object sender, EventArgs e) => paint = 4; // Target

        // Initialization
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeRandom();
        }

        // Exit
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ====== 核心邏輯 ======

        private void BuildPoints()
        {
            int margin = 5;
            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                    points[x, y] = new Point(margin + between * x, margin + between * y);
        }

        private void ClearGrid()
        {
            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                    grid[x, y] = CellType.Empty;
            start = target = (-1, -1);
            path.Clear();
        }

        private void InitializeRandom()
        {
            ClearGrid();

            // 32 個障礙
            int count = 0;
            while (count < 32)
            {
                int x = rand.Next(N), y = rand.Next(N);
                if (grid[x, y] == CellType.Empty)
                {
                    grid[x, y] = CellType.Obstacle;
                    count++;
                }
            }

            // 放 S
            while (true)
            {
                int x = rand.Next(N), y = rand.Next(N);
                if (grid[x, y] == CellType.Empty)
                {
                    grid[x, y] = CellType.Start;
                    start = (x, y);
                    break;
                }
            }

            // 放 T
            while (true)
            {
                int x = rand.Next(N), y = rand.Next(N);
                if (grid[x, y] == CellType.Empty)
                {
                    grid[x, y] = CellType.Target;
                    target = (x, y);
                    break;
                }
            }

            var ok = ReplanPath();
            MessageBox.Show(ok ? "規劃路線成功" : "規劃路線失敗");
            panel1.Invalidate();
        }

        private bool ReplanPath()
        {
            path.Clear();
            if (start.x < 0 || target.x < 0) return false;
            return BfsAndBuildPath(start.x, start.y, target.x, target.y);
        }

        // BFS + 回溯路徑（4 方向）
        private bool BfsAndBuildPath(int sx, int sy, int tx, int ty)
        {
            var q = new Queue<(int x, int y)>();
            var prev = new (int x, int y)?[N, N];
            var vis = new bool[N, N];

            q.Enqueue((sx, sy));
            vis[sx, sy] = true;

            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            while (q.Count > 0)
            {
                var (x, y) = q.Dequeue();
                if (x == tx && y == ty)
                {
                    // 回溯
                    var cur = (x, y);
                    var stack = new Stack<Point>();
                    while (!(cur.x == sx && cur.y == sy))
                    {
                        stack.Push(points[cur.x, cur.y]);
                        cur = prev[cur.x, cur.y]!.Value;
                    }
                    stack.Push(points[sx, sy]);

                    path.Clear();
                    while (stack.Count > 0) path.Add(stack.Pop());
                    return true;
                }

                for (int k = 0; k < 4; k++)
                {
                    int nx = x + dx[k], ny = y + dy[k];
                    if (nx < 0 || nx >= N || ny < 0 || ny >= N) continue;
                    if (vis[nx, ny]) continue;
                    if (grid[nx, ny] == CellType.Obstacle) continue;

                    vis[nx, ny] = true;
                    prev[nx, ny] = (x, y);
                    q.Enqueue((nx, ny));
                }
            }
            return false;
        }

        // ====== 繪圖小工具（吃 Graphics） ======

        private void DrawBlock(Graphics g, Point center)
        {
            using var brush = new SolidBrush(Color.Black);
            int d = 18;
            g.FillEllipse(brush, center.X - d / 2, center.Y - d / 2, d, d);
        }

        private void DrawStart(Graphics g, Point center)
        {
            using var pen = new Pen(Color.Blue, 3);
            int d = 16;
            g.DrawEllipse(pen, center.X - d / 2, center.Y - d / 2, d, d);
        }

        private void DrawEnd(Graphics g, Point center)
        {
            using var pen = new Pen(Color.Red, 3);
            int d = 16;
            g.DrawRectangle(pen, center.X - d / 2, center.Y - d / 2, d, d);
        }
    }
}
