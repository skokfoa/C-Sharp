using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_Q5
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int first = int.Parse(textBox1.Text);
            int last = int.Parse(textBox2.Text);

            int result = first * last;

            if(result.ToString() == textBox3.Text)
            {
                label6.Text = "";
                label5.Text = "Very Good!";

                return;
            }

            string[] steps = new string[4];

            int remain = last % 10;
            int sum = first + remain;

            steps[0] = $"(1){first}+{remain}={sum}";

            int div = first / 10;

            steps[1] = $"(2){sum}X{div * 10}={sum * div * 10}";

            sum *= div * 10;

            int _result = (first % 10) * remain;

            steps[2] = $"(3){first % 10}X{remain}={_result}";

            steps[3] = $"(4){sum}+{_result}={sum + _result}";

            label6.Text = "is wrong";
            label5.Text = string.Join("\n", steps);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setup();
        }

        public void setup()
        {
            int base_num = random.Next(1, 10) * 10;

            textBox1.Text = (base_num + random.Next(0, 10)).ToString();
            textBox2.Text = (base_num + random.Next(0, 10)).ToString();
            textBox3.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setup();
        }
    }
}
