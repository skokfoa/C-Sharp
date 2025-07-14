namespace Q5
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "x的範圍=";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 27);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(176, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(49, 27);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(190, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(49, 27);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "輸入實數數值或二進位字串";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 252);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(244, 27);
            this.textBox4.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(283, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "轉換";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ans = ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "精確度小數點下幾位";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 360);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}

