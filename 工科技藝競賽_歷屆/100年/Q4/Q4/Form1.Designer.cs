namespace Q4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.開啟檔案FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟色彩影像OpenColorImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束離開ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能要求ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色彩影像轉灰階影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.劃出灰階影像直方圖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求最小灰階和最大灰階ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求出現最多之灰階和此機率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟檔案FileToolStripMenuItem,
            this.功能要求ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 開啟檔案FileToolStripMenuItem
            // 
            this.開啟檔案FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟色彩影像OpenColorImageToolStripMenuItem,
            this.結束離開ExitToolStripMenuItem});
            this.開啟檔案FileToolStripMenuItem.Name = "開啟檔案FileToolStripMenuItem";
            this.開啟檔案FileToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.開啟檔案FileToolStripMenuItem.Text = "開啟檔案(File)";
            // 
            // 開啟色彩影像OpenColorImageToolStripMenuItem
            // 
            this.開啟色彩影像OpenColorImageToolStripMenuItem.Name = "開啟色彩影像OpenColorImageToolStripMenuItem";
            this.開啟色彩影像OpenColorImageToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.開啟色彩影像OpenColorImageToolStripMenuItem.Text = "開啟色彩影像(OpenColorImage)";
            this.開啟色彩影像OpenColorImageToolStripMenuItem.Click += new System.EventHandler(this.開啟色彩影像OpenColorImageToolStripMenuItem_Click);
            // 
            // 結束離開ExitToolStripMenuItem
            // 
            this.結束離開ExitToolStripMenuItem.Name = "結束離開ExitToolStripMenuItem";
            this.結束離開ExitToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.結束離開ExitToolStripMenuItem.Text = "結束離開(Exit)";
            this.結束離開ExitToolStripMenuItem.Click += new System.EventHandler(this.結束離開ExitToolStripMenuItem_Click);
            // 
            // 功能要求ToolStripMenuItem
            // 
            this.功能要求ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.色彩影像轉灰階影像ToolStripMenuItem,
            this.劃出灰階影像直方圖ToolStripMenuItem,
            this.求最小灰階和最大灰階ToolStripMenuItem,
            this.求出現最多之灰階和此機率ToolStripMenuItem});
            this.功能要求ToolStripMenuItem.Name = "功能要求ToolStripMenuItem";
            this.功能要求ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.功能要求ToolStripMenuItem.Text = "功能要求";
            // 
            // 色彩影像轉灰階影像ToolStripMenuItem
            // 
            this.色彩影像轉灰階影像ToolStripMenuItem.Name = "色彩影像轉灰階影像ToolStripMenuItem";
            this.色彩影像轉灰階影像ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.色彩影像轉灰階影像ToolStripMenuItem.Text = "色彩影像轉灰階影像";
            this.色彩影像轉灰階影像ToolStripMenuItem.Click += new System.EventHandler(this.色彩影像轉灰階影像ToolStripMenuItem_Click);
            // 
            // 劃出灰階影像直方圖ToolStripMenuItem
            // 
            this.劃出灰階影像直方圖ToolStripMenuItem.Name = "劃出灰階影像直方圖ToolStripMenuItem";
            this.劃出灰階影像直方圖ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.劃出灰階影像直方圖ToolStripMenuItem.Text = "劃出灰階影像直方圖";
            this.劃出灰階影像直方圖ToolStripMenuItem.Click += new System.EventHandler(this.劃出灰階影像直方圖ToolStripMenuItem_Click);
            // 
            // 求最小灰階和最大灰階ToolStripMenuItem
            // 
            this.求最小灰階和最大灰階ToolStripMenuItem.Name = "求最小灰階和最大灰階ToolStripMenuItem";
            this.求最小灰階和最大灰階ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.求最小灰階和最大灰階ToolStripMenuItem.Text = "求最小灰階和最大灰階";
            this.求最小灰階和最大灰階ToolStripMenuItem.Click += new System.EventHandler(this.求最小灰階和最大灰階ToolStripMenuItem_Click);
            // 
            // 求出現最多之灰階和此機率ToolStripMenuItem
            // 
            this.求出現最多之灰階和此機率ToolStripMenuItem.Name = "求出現最多之灰階和此機率ToolStripMenuItem";
            this.求出現最多之灰階和此機率ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.求出現最多之灰階和此機率ToolStripMenuItem.Text = "求出現最多之灰階和此機率";
            this.求出現最多之灰階和此機率ToolStripMenuItem.Click += new System.EventHandler(this.求出環最多之灰階和此機率ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "彩色影像(Color Image)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(384, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 350);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "灰階影像(Gray Level Image)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(354, 323);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(756, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 350);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "灰階影像直方圖(Histogram of Gray Level Image)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(68, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "最小灰階(亮度)為:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(87, 429);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 33);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(333, 429);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 33);
            this.textBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(314, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "最大灰階(亮度)為:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox3.Location = new System.Drawing.Point(607, 429);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 33);
            this.textBox3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(567, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "出現最多灰階(亮度)為:";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox4.Location = new System.Drawing.Point(893, 429);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(138, 33);
            this.textBox4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(843, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "最多灰階(亮度)之機率為:";
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 50D;
            chartArea1.AxisX.Maximum = 300D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisX.Title = "Grayscale";
            chartArea1.AxisX2.Maximum = 50D;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.Interval = 500D;
            chartArea1.AxisY.Maximum = 3000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Title = "Quantity";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(7, 21);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(399, 323);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 492);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 開啟檔案FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟色彩影像OpenColorImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束離開ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能要求ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 色彩影像轉灰階影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 劃出灰階影像直方圖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求最小灰階和最大灰階ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求出現最多之灰階和此機率ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

