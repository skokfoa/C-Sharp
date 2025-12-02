using System;
using System.Drawing;
using System.Windows.Forms;

namespace _106_Q3
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        readonly int[,] templates =
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {0, 1, 1, 0, 0, 0, 0 },
            {0, 0, 0, 0, 1, 1, 0 },
            {1, 1, 0, 1, 1, 0, 1 },
            {1, 1, 1, 1, 0, 0, 1 },
            {0, 1, 1, 0, 0, 1, 1 },
            {1, 0, 1, 1, 0, 1, 1 },
            {0, 0, 1, 1, 1, 1, 1 },
            {1, 1, 1, 0, 0, 0, 0 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 0, 1, 1 },
            {1, 1, 1, 0, 0, 1, 1 }
        };

        readonly int[] numbers = { 0, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 9};

        readonly int[] displays = { 0, 0, 0, 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(GetBoxes(), sender);

            displays[index] = displays[index] == 1 ? 0 : 1;

            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            for (int i = 0; i < displays.Length; i++)
            {
                displays[i] = random.Next(0, 2);
            }

            Recognize();

            Update();
        }

        public void Recognize()
        {
            int found = -1;

            for (int i = 0; i < 12; i++)
            {
                bool same = true;

                for(int j = 0; j < displays.Length; j++)
                {
                    if (templates[i, j] != displays[j])
                    {
;                       same = false;
                        break;
                    }
                }

                if(same)
                {
                    found = numbers[i];
                    break;
                }
            }

            if (found <= 0)
                textBox1.Text = "非數字";
            else
                textBox1.Text = found.ToString();
        }

        public void Update()
        {
            PictureBox[] boxes = GetBoxes();

            for(int i = 0; i < boxes.Length;i++)
            {
                boxes[i].BackColor = displays[i] == 1 ? Color.Red : Color.White;
            }
        }

        public PictureBox[] GetBoxes()
        {
            return new PictureBox[] {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(PictureBox box in GetBoxes())
            {
                box.Click += pictureBox_Click;
            }

            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recognize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
