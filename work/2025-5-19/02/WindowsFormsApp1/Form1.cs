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
        public Form1()
        {
            InitializeComponent();
            Perfect();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Perfect()
        {
            for (int i = 1; i <= 10000; i++)
            {
                int sum = new int();
                List<int> list = new List<int>();
                for (int j = 1; j < i ; j++)
                {
                    if(i%j == 0)
                    {
                        list.Add(j);
                    }
                }
                foreach (int item in list)
                {
                    sum += item;
                }

                if (i == sum)
                {
                    string a = string.Join("+", list);
                    label1.Text += $"{i} = {a}\r\n";
                }
            }
        }
    }
}
