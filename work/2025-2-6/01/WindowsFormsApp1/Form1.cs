using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int a, b;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string[] shape = { "♣", "♦", "♥", "♠" };
            string[] number = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            a = random.Next(0, 4);
            b = random.Next(0, 13);
            textBox1.Text = shape[a];
            textBox2.Text = number[b];
        }
    }    
}
