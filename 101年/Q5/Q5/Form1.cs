using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        Timer timer = new Timer();
        byte[] input = new byte[9];
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
                input[i] = (byte)(number);
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
            timer = new Timer();
            timer.Interval = 1000 / 2;
            List<Node> path = solve(input);
            if (path != null)
                textBox20.Text = $"{path.Count}";
            else
                textBox20.Text = $"無解";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        List<Node> solve(byte[] source)
        {
            Queue<Node> queue = new Queue<Node>();

            HashSet<int> book = new HashSet<int>();
            Node start = new Node(source, null);

            
            queue.Enqueue(start);
            book.Add(start.ToSequence());

            while (queue.Count > 0)
            {
                Node now = queue.Dequeue();
                
                if (now.check(now.status))
                {
                    return PathTrace(now);
                }
                List<Node> nextPush = move(now);
                foreach (Node next in nextPush)
                {
                    int sequence = next.ToSequence();
                    if (!book.Contains(sequence))
                    {
                        book.Add(sequence);
                        queue.Enqueue(next);
                    }
                }
                for(int i = 0;i < now.status.Length; ++i)
                {
                    first[i].Text = now.status[i].ToString();
                }
            }

            return null;

        }

        List<Node> move(Node now)
        {
            textBox21.Text += $"{Array.IndexOf<byte>(now.status, 0)}";
            int index = Array.IndexOf<byte>(now.status, 0);
            int col = index % 3;
            int row = index / 3;


            List<Node> nextPush = new List<Node>();
            byte[] next;

            if (row != 0) // top
            {
                next = (byte[])now.status.Clone();
                swap(ref next[index], ref next[index - 3]);
                nextPush.Add(new Node(next, now));
            }

            if (row != 2) // bottom
            {
                next = (byte[])now.status.Clone();
                swap(ref next[index % next.Length], ref next[(index + 3) % next.Length]);
                nextPush.Add(new Node(next, now));
            }

            if (col != 0) // left
            {
                next = (byte[])now.status.Clone();
                swap(ref next[index % next.Length], ref next[(index - 1) % next.Length]);
                nextPush.Add(new Node(next, now));
            }

            if (col != 2) // right
            { 
                next = (byte[])now.status.Clone();
                swap(ref next[index % next.Length], ref next[(index + 1) % next.Length]);
                nextPush.Add(new Node(next, now));
            }

            return nextPush;
        }

        List<Node> PathTrace(Node now)
        {
            // 回朔路徑
            List<Node> path = new List<Node>();
            while (now.father != null)
            {
                path.Add(now);
                now = now.father;
            }
            path.Reverse();
            return path;
        }

        void swap<T> (ref T a,ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public class Node
        {
            public byte[] status;
            public Node father;
            public Node(byte[] status, Node father)
            {
                this.status = status;
                this.father = father;
            }
            public int ToSequence()
            {
                int result = 0;
                for (int i = 0; i < status.Length; i++)
                    result = result * 10 + status[i];

                return result;
            }

            public bool check(byte[] status)
            {
                byte[] ans = new byte[9]{1, 2, 3, 8, 0, 4, 7, 6, 5};
                for (int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < ans.Length; j++)
                    {
                        if ((status[j] + i) == ans[j])
                        {
                            ans[j] = 10; // 已經找到
                            break;
                        }
                    }
                }
            }
        }
    }
}
