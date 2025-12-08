using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            byte[] picture = File.ReadAllBytes(path);

            string enter = textBox1.Text;
            int nowByte = 64;
            
            for(int i = 63; i < 95; i++)
            {
                if (i % 2 == 0) picture[i] += 0b10000000;
            }

            string len = Convert.ToString(enter.Length, 2).PadLeft(16, '0');

            len.Reverse();

            for(int i = 0; i < 16; i++)
            {
                if (len[i] == '1')
                {
                    picture[i + 95] += 0x80;
                }
            }

            int nowbyte = 111;
            foreach(int n in picture)
            {
                string binary = Convert.ToString(n, 2).PadLeft(8,'0');
                binary.Reverse();

                for(int i = 0; i < binary.Length; i++)
                {
                    if (binary[i] == '1') picture[nowbyte + i] += 0x80;
                }
                nowbyte += 8;
            }

            path = @".\a2.bmp";

            File.WriteAllBytes(path, picture);
        }
    }
}
