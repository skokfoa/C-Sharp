using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("輸入錯誤");
                return;
            }

            if (textBox1.Text.Length != 10 || textBox2.Text.Length != 8 || textBox3.Text.Length != 10)
            {
                MessageBox.Show("輸入錯誤");
                return;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("輸入錯誤");
                return;
            }
            
            string ID = textBox1.Text;
            string Born = textBox2.Text;
            int Merry = comboBox1.SelectedIndex;
            int Education = comboBox2.SelectedIndex;
            string PhoneNumber = textBox3.Text;

            string Lest8ID   = Convert.ToString(int.Parse(ID.Substring(2)), 2).PadLeft(27, '0');
            string IDLetter  = Convert.ToString(char.ToUpper(ID[0]) - 'A', 2).PadLeft(5,'0');

            string IDByte    = IDLetter + (ID[1] - '1') + Lest8ID;

            string day   = Convert.ToString(int.Parse(Born.Substring(6, 2)), 2).PadLeft(5, '0');
            string month = Convert.ToString(int.Parse(Born.Substring(4, 2)), 2).PadLeft(4, '0');
            string year  = Convert.ToString(int.Parse(Born.Substring(0,4)) - 1900, 2).PadLeft(7, '0');

            string BornByte = year + month + day;

            string MarryByte = Merry.ToString();

            string EducationByte = Convert.ToString(Education, 2).PadLeft(3, '0');

            string PhoneNumByte = Convert.ToString(int.Parse(PhoneNumber.Substring(2)),2).PadLeft(27, '0');

            string result = PhoneNumByte + EducationByte + MarryByte + BornByte + IDByte;
            string output = string.Empty;

            for(int i = 0; i < result.Length / 4; i++)
            {
                int change = Convert.ToInt32(result.Substring(i * 4, 4), 2);
                output = output + change.ToString("X");
            }

            textBox4.Text = output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 20)
            {
                MessageBox.Show("輸入錯誤");
                return;
            }

            string input = textBox4.Text;
            string binary = string.Empty;

            foreach (char c in input)
            {
                int num = Convert.ToInt32(c.ToString(), 16);
                binary = binary + Convert.ToString(num, 2).PadLeft(4,'0');
            }

            string phoneNumByte = binary.Substring(0, 27);
            string phoneNum = "09" + Convert.ToInt32(phoneNumByte, 2).ToString();

            string EducationByte = binary.Substring(27, 3);
            int Education = Convert.ToInt32(EducationByte, 2);

            int Marry = int.Parse(binary.Substring(30, 1));

            int year     = Convert.ToInt32(binary.Substring(31, 7), 2) + 1900;
            int month    = Convert.ToInt32(binary.Substring(38, 4), 2);
            int day      = Convert.ToInt32(binary.Substring(42, 5), 2);

            string born = year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString();

            char numLetter = (char)('A' + Convert.ToInt32(binary.Substring(47, 5), 2));
            char gender = (char)('1' + Convert.ToInt32(binary.Substring(52, 1), 2));

            string IDByte = Convert.ToInt32(binary.Substring(53, 27), 2).ToString();

            string ID = numLetter.ToString() + gender.ToString() + IDByte;

            textBox1.Text = ID;
            textBox2.Text = born;
            comboBox1.SelectedIndex = Marry;
            comboBox2.SelectedIndex = Education;
            textBox3.Text = phoneNum;


            //Y059746147
            //M159746147
        }
    }
}
