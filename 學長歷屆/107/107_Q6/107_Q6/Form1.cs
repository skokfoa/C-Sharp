using System;
using System.Windows.Forms;

namespace _107_Q6
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomSet(0, 49);
        }

        public void RandomSet(int index, int digit)
        {
            TextBox[] boxes = GetBoxes(index);

            string numbers = "";

            for(int i = 0; i < digit; i++)
            {
                numbers += random.Next(0, 2);
            }

            boxes[0].Text = numbers;
        }

        public string[] GetNumbers()
        {
            return new string[]
            {
                textBox1.Text,
                textBox4.Text,
                textBox6.Text,
                textBox8.Text,
                textBox10.Text,
            };
        }

        public string[] GetLabels()
        {
            return new string[]
            {
                textBox2.Text,
                textBox3.Text,
                textBox5.Text,
                textBox7.Text,
                textBox9.Text,
            };
        }

        public TextBox[] GetBoxes(int index)
        {
            if (index == 0)
                return new TextBox[]
                {
                    textBox11, textBox13, textBox12
                };

            return new TextBox[]
            {
                textBox16, textBox14, textBox15
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandomSet(1, 41);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Decoding(0);
            Decoding(1);
        }

        public void Decoding(int index)
        {
            TextBox[] boxes = GetBoxes(index);

            string[] numbers = GetNumbers();
            string[] labels = GetLabels();

            string source = boxes[0].Text;
            string result = "";

            while (source.Length > 0)
            {
                bool has = false;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (source.StartsWith(numbers[i]))
                    {
                        result += labels[i];
                        source = source.Substring(numbers[i].Length);
                        has = true;

                        break;
                    }
                }

                if (!has)
                {
                    break;
                }
            }

            if(source.Length > 0)
            {
                boxes[1].Text = "不合理";
                boxes[2].Text = "";
                return;
            }

            boxes[2].Text = result;
            boxes[1].Text = "";
        }
    }
}
