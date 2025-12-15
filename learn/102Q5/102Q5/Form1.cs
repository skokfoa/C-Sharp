using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBox1, textBox2, textBox3};
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mut = int.Parse(textBox1.Text);
            int div = int.Parse(textBox2.Text);
            int ans = int.Parse(textBox3.Text);

            if (mut * div == ans)
            {
                label5.Text = "Very Good!";
                return;
            }
            else
            {
                label5.Text = "is wrong";
            }

            int[] mutnum = { mut / 10, mut % 10 };
            int[] divnum = { div / 10, div % 10 };

            int sum = (mut + divnum[1]);

            label6.Text = $"(1) {mut}+{divnum[1]}={mut + divnum[1]}\r\n"+
                          $"(2) {sum}*{mutnum[0]*10}={sum* mutnum[0] * 10}\r\n" +
                          $"(3) {mutnum[1]}*{divnum[1]}={mutnum[1] * divnum[1]}\r\n"+
                          $"(4) {sum * mutnum[0] * 10}+{mutnum[1] * divnum[1]}={(sum * mutnum[0] * 10)+(mutnum[1] * divnum[1])}";


            
        }
    }
}
