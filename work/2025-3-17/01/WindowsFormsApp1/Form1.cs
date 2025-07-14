using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBox3.Text.ToUpper();
            char[] text = input.ToCharArray();
            char[,] sec = { { 'A', 'K' }, { 'Z', 'E' }, { 'C', 'H' }, { 'S', 'U' },
                            { 'R', 'V' }, { 'K', 'N' }, { 'P', 'T' }, { 'B', 'C' }, };
            string[] aeiou = { "A", "E", "I", "O", "U" };
            string[] jqk = { "J", "Q", "K" };
            string[] xyz = { "X", "Y", "Z" };

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                c = (char)(c + 2);

                if (c > 90)
                {
                    c = (char)(c - 26);
                }

                text[i] = c;
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (text[i] == sec[j,0])
                    {
                        text[i] = sec[j,1];
                        break;
                    }
                }
            }

            for (int i = 0;i < text.Length; i++)
            {
                for (int j = 0; j < aeiou.Length; j++)
                {
                    if (text[i].ToString() == aeiou[j])
                    {
                        char c = text[i];
                        c = (char)(c + 32);
                        text[i] = c;
                    }
                }

                for (int j = 0; j < jqk.Length; j++)
                {
                    if (text[i].ToString() == jqk[j])
                    {
                        switch (j)
                        {
                            case 0:
                                text[i] = '1';
                                break;

                            case 1:
                                text[i] = '2';
                                break;

                            case 2:
                                text[i] = '3';
                                break;
                        }
                    }
                }

                for (int j = 0; j < xyz.Length; j++)
                {
                    if (text[i].ToString() == xyz[j])
                    {
                        text[i] = '?';
                    }
                }
            }

            print(text);

        }

        private void print(char[] text)
        {
            label1.Text = "";

            for (int j = 0; j < text.Length; j++)
            {
                label1.Text += text[j];
            }
        }
        
    }
}
