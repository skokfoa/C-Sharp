using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _93_Q2
{
    public partial class Form1 : Form
    {
        string fileName = "";

        bool modified = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("確定要儲存到新的檔案嗎?", "另存新檔", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            var dialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "txt files(*.txt)|*.txt"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            fileName = dialog.FileName;
            Save();
        }

        public void Save()
        {
            File.WriteAllText(fileName, richTextBox1.Text);
            modified = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            modified = true;
            RefreshStatus();
        }

        public void RefreshStatus()
        {
            if (fileName.Length > 0)
                ActiveForm.Text = $"{fileName} - MyNotePad";
            else ActiveForm.Text = $"未命名 - MyNotePad";

            toolStripStatusLabel1.Text = $"行：{richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1}/{richTextBox1.Text.Split('\n').Count()}";
        }

        private void richTextBox1_CursorChanged(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modified)
                return;

            var dialog = MessageBox.Show("尚有未儲存的變更\r\n是否要先存檔", "MyNotePad", MessageBoxButtons.YesNoCancel);

            if(dialog == DialogResult.Cancel)
                e.Cancel = true;

            if(dialog == DialogResult.OK)
            {
                if (!CheckFolder())
                    return;

                Save();
            }
        }

        private void 新檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = "";
            modified = false;
            richTextBox1.Text = "";

            RefreshStatus();
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "txt files(*.txt)|*.txt"
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                richTextBox1.Text = File.ReadAllText(dialog.FileName);
                modified = false;

                RefreshStatus();
            }
        }

        private void 儲存檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFolder())
                return;

            Save();
        }

        public bool CheckFolder()
        {
            if (fileName.Length == 0)
            {
                var dialog = new SaveFileDialog
                {
                    InitialDirectory = Application.StartupPath,
                    Filter = "txt files (*.txt)|*.txt"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                    return false;

                fileName = dialog.FileName;
                RefreshStatus();
            }

            return true;
        }
    }
}
