using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int Address_bus = random.Next(16, 52 + 1);
            int Bytes_per_address = random.Next(1, 8 + 1);

            Textbox_empty();

            textBox1.Text = $"{Address_bus}";
            textBox2.Text = $"{Bytes_per_address}B";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int Memory_space_bytes = random.Next(4);
            int Memory_space_num = new int();
            int Bytes_per_address = random.Next(1, 9);
            string Memory_space = string.Empty;

            switch (Memory_space_bytes)
            {
                case 0:
                    Memory_space_num = random.Next(512, 1024);
                    Memory_space = Memory_space_num.ToString() + "KB";
                    break;
                case 1:
                    Memory_space_num = random.Next(1, 1024);
                    Memory_space = Memory_space_num.ToString() + "MB";
                    break;
                case 2:
                    Memory_space_num = random.Next(1, 1024);
                    Memory_space = Memory_space_num.ToString() + "GB";
                    break;
                case 3:
                    Memory_space_num = random.Next(1, 32768 + 1);
                    Memory_space = Memory_space_num.ToString() + "TB";
                    break;
            }

            Textbox_empty();

            textBox6.Text = Memory_space;
            textBox5.Text = $"{Bytes_per_address}B";
        }
        private void Textbox_empty()
        {
            TextBox[] textBox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            foreach(var i  in textBox)
            {
                i.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Address_bus = int.Parse(textBox1.Text);
            int Bytes_per_address = int.Parse(textBox2.Text.TrimEnd('B'));
            int Memory_space_bytes = new int();
            double Memory_space_num = new double();
            string Memory_space = string.Empty;


            Address_bus += Math.Log(Bytes_per_address, 2);

            Memory_space_bytes = (int)Address_bus / 10;
            if(Address_bus > 50)
            {
                Memory_space_bytes = (int)(Address_bus / 10) - 1;
            }
            else
            {
                Memory_space_bytes = (int)(Address_bus / 10);
            }

            Address_bus -= Memory_space_bytes * 10;

            Memory_space_num = Math.Pow(2, Address_bus);

            switch (Memory_space_bytes)
            {
                case 1:
                    Memory_space = Memory_space_num.ToString() + "KB";
                    break;
                case 2:
                    Memory_space = Memory_space_num.ToString() + "MB";
                    break;
                case 3:
                    Memory_space = Memory_space_num.ToString() + "GB";
                    break;
                case 4:
                    Memory_space = Memory_space_num.ToString() + "TB";
                    break;
                default:
                    Memory_space = Memory_space_num.ToString() + "TB";
                    break;
            }

            textBox3.Text = Memory_space;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double Address_bus = new double();
            int Bytes_per_address = int.Parse(textBox5.Text.TrimEnd('B'));
            string Memory_space = textBox6.Text.TrimEnd('B');
            char[] input = Memory_space.ToCharArray();
            double Memory_space_num = new double();

            Memory_space = string.Empty;
            for (int i = 0; i < input.Length - 1; i++)
            {
                Memory_space += input[i];
            }

            Memory_space_num = int.Parse(Memory_space);

            switch(input[input.Length - 1])
            {
                case 'K':
                    Address_bus = 10;
                    break;
                case 'M':
                    Address_bus = 20;
                    break;
                case 'G':
                    Address_bus = 30;
                    break;
                case 'T':
                    Address_bus = 40;
                    break;
            }

            Address_bus += Math.Log(Memory_space_num, 2) - Math.Log(Bytes_per_address, 2);

            if (Address_bus > (int)Address_bus)
            {
                Address_bus = (int)Address_bus + 1;
            }

            textBox4.Text = Address_bus.ToString();
        }
    }
}
