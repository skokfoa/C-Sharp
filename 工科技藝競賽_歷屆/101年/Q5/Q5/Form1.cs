using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Q5
{
    public partial class Form1 : Form
    {
        TextBox[] first;
        TextBox[] second;
        public static string[] ans = new string[8];
        public Form1()
        {
            InitializeComponent();
            first = new TextBox[9]
            {
                textBox1, textBox2, textBox3,
                textBox4, textBox5, textBox6,
                textBox7, textBox8, textBox9
            };

            second = new TextBox[9]
            {
                textBox10, textBox11, textBox12,
                textBox13, textBox14, textBox15,
                textBox16, textBox17, textBox18
            };

            ans = new string[] { "123804765", "812703654", "781602543", "678501432"
                                ,"567408321", "456307218", "345206187", "234105876"};

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                int number;
                do
                {
                    number = random.Next(0, 9);
                } while (numbers.Contains(number));
                numbers.Add(number);
                if (number != 0)
                {
                    first[i].Text = number.ToString();
                }
                else
                {
                    first[i].Text = string.Empty;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ✅ 這裡決定你要從哪一組 TextBox 讀起點：first 或 second
            TextBox[] src = second; // 如果要用亂數那組就改成 first

            byte[] data = new byte[9];
            for (int i = 0; i < src.Length; i++)
                data[i] = src[i].Text != string.Empty ? byte.Parse(src[i].Text) : (byte)0;

            // （建議）先檢查可解性
            if (!IsSolvable(data))
            {
                textBox20.Text = "無解";
                return;
            }

            Node start = new Node(data);
            Node final = null;

            Queue<Node> keep = new Queue<Node>();
            HashSet<string> visit = new HashSet<string>();

            keep.Enqueue(start);
            visit.Add(Node.change(start.data)); // ✅ 入隊時就標記

            while (keep.Count > 0)
            {
                Node now = keep.Dequeue();

                if (check(now))
                {
                    final = now;
                    break;
                }

                foreach (Node nxt in Move(now))
                {
                    string key = Node.change(nxt.data);
                    if (visit.Add(key))
                        keep.Enqueue(nxt);
                }
            }

            if (final == null)
            {
                textBox20.Text = "找不到解"; // 或顯示步數為 0
                return;
            }

            List<byte[]> path = find(final);
            // path 目前是從目標 → 起點；如果你想顯示起點 → 目標：
            path.Reverse();

            textBox20.Text = path.Count.ToString();

            // 你也可以把 path 的每一步填回 UI（略）
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static List<Node> Move(Node now)
        {
            List<Node> output = new List<Node>();
            var a = now.data;

            // 找到 0 的位置（空白）
            int pos = Array.IndexOf(a, (byte)0);
            int x = pos % 3;
            int y = pos / 3;

            // 四個方向：右、左、下、上
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int k = 0; k < 4; k++)
            {
                int nx = x + dx[k];
                int ny = y + dy[k];
                if (nx >= 0 && nx < 3 && ny >= 0 && ny < 3)
                {
                    int npos = ny * 3 + nx;

                    // 深拷貝，再交換
                    byte[] b = (byte[])a.Clone();
                    swap(ref b[pos], ref b[npos]);

                    output.Add(new Node(b, now));
                }
            }

            return output;
        }

        private static bool check(Node now)
        {
            string chs = Node.change(now.data);
            foreach(string s in ans)
            {
                if (chs == s) return true;
            }

            return false;
        }

        private static List<byte[]> find(Node now)
        {
            List<byte[]> seq = new List<byte[]>();
            for (Node cur = now; cur != null; cur = cur.father)
                seq.Add(cur.data);
            return seq;
        }

        private static bool IsSolvable(byte[] a)
        {
            int inv = 0;
            for (int i = 0; i < 9; i++)
            {
                if (a[i] == 0) continue;
                for (int j = i + 1; j < 9; j++)
                {
                    if (a[j] == 0) continue;
                    if (a[i] > a[j]) inv++;
                }
            }
            // 3×3 拼圖：反序數為偶數才可解
            return (inv % 2 == 0);
        }

        private static void swap(ref byte a, ref byte b)
        {
            byte temp = a;
            a = b;
            b = temp;
        }
    }

    public class Node
    {
        public byte[] data { get; set; }
        public Node father { get; set; }

        public Node(byte[] data, Node father = null)
        {
            this.data = data;
            this.father = father;
        }

        public static string change(byte[] data)
        {
            string output = string.Empty;

            for(int i = 0; i < data.Length; i++)
            {
                output = output + data[i];
            }

            return output;
        }
    }
}
