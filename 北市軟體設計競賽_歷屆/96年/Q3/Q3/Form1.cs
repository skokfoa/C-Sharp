using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.AxHost;

namespace Q3
{
    public partial class Form1 : Form
    {
        private enum state
        {
            Ok = 0,
            Len = 1,
            KFirst = 2,
            OneLOnly = 3,
            MLastOrLastSecond = 4,
            HaveKNoN = 5,
            NoLOLast = 6
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();


            switch (constraint(input))
            {
                case state.Ok:
                    textBox2.Text = $"{input}是正確的密碼文字";
                    break;
                default:
                    textBox2.Text = $"{input}不是正確的密碼文字";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox3.Text.Trim();
            switch (constraint(input))
            {
                case state.Len:
                    textBox4.Text = "本輸入密碼無法滿足第1條件";
                    break;
                case state.KFirst:
                    textBox4.Text = "本輸入密碼無法滿足第2條件";
                    break;
                case state.OneLOnly:
                    textBox4.Text = "本輸入密碼無法滿足第3條件";
                    break;
                case state.MLastOrLastSecond:
                    textBox4.Text = "本輸入密碼無法滿足第4條件";
                    break;
                case state.HaveKNoN:
                    textBox4.Text = "本輸入密碼無法滿足第5條件";
                    break;
                case state.NoLOLast:
                    textBox4.Text = "本輸入密碼無法滿足第6條件";
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            string input = textBox5.Text.Trim();

            char[] letters = { 'K', 'L', 'M', 'N', 'O' };

            int index = input.IndexOf('X');

            char[] chars = input.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                chars[index] = letters[i];
                if (constraint(new string(chars)) == state.Ok) break;
            }

            input = new string(chars);
            textBox7.Text = input;

            input = textBox6.Text.Trim();

            index = input.IndexOf('X');

            chars = input.ToCharArray();

            for (int i = 0; i < letters.Length && index != -1; i++)
            {
                chars[index] = letters[i];
                if (constraint(new string(chars)) == state.Ok) break;
            }

            input = new string(chars);
            textBox8.Text = input;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> password = new List<string>();
            string[] letters = { "L", "M", "N", "O" };

            for(int i = 0; i < letters.Length; i++)
            {
                string s = letters[i] + letters[i] + letters[i];
                if (constraint(s) == state.Ok) password.Add(s);
            }

            textBox9.Text = password.Count.ToString();
            textBox10.Text = string.Join("、", password);
        }

        private static state constraint(string password)
        {
            if (password.Length < 3) return state.Len;

            if (password[0] == 'K') return state.KFirst;

            if (password.Contains("L") && password.Count(c => c == 'L') < 2) return state.OneLOnly;

            if (password[password.Length - 1] == 'M' || 
                password[password.Length - 2] == 'M') 
                return state.MLastOrLastSecond;

            if (password.Contains("K") && !password.Contains("N")) return state.HaveKNoN;

            if (password[password.Length - 1] == 'O' && !password.Contains("L")) return state.NoLOLast;

            return state.Ok;
        }

        private void textbox_change(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            int cursorPos = tb.SelectionStart;
            string upper = tb.Text.ToUpper();

            tb.Text = upper;
            tb.SelectionStart = cursorPos;
        }
    }
}
