using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _92_Q3
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();
        readonly Font font = new Font("微軟正黑體", 12);
        readonly Brush brush = new SolidBrush(Color.Black);

        bool draw = false;
        int amount, index;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            amount = int.Parse(textBox1.Text);
            index = int.Parse(textBox2.Text);

            draw = true;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);

            if (!draw)
                return;

            int[] numbers = new int[amount];
            
            for(int i = 0; i < amount; i++)
            {
                int number;

                do
                {
                    number = random.Next(0, 1000);
                } while (numbers.Contains(number));

                numbers[i] = number;
            }

            for(int i = 0; i < index; i++)
                e.Graphics.DrawString(i.ToString(), font, brush, i * 45, 0);

            e.Graphics.DrawLine(new Pen(Color.Black), 0, 25, index * 45, 25);

            int[] indexs = new int[index];

            for (int i = 0; i < amount; i++)
                e.Graphics.DrawString(numbers[i].ToString(), font, brush, (numbers[i] % index) * 45, ++indexs[numbers[i] % index] * 20 + 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
