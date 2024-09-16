namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.построитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчиститьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритм8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_iterations = new System.Windows.Forms.TextBox();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            legend3.Name = "Legend1";
            legend3.Title = "Графики";
            legend3.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.ThickLine;
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.Legend = "Legend1";
            series5.LegendText = "Фактический";
            series5.Name = "Series1";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.LegendText = "Предпологаемый";
            series6.Name = "Series2";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(821, 646);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьГрафикToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1158, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // построитьГрафикToolStripMenuItem
            // 
            this.построитьГрафикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчиститьГрафикToolStripMenuItem,
            this.отчиститьToolStripMenuItem});
            this.построитьГрафикToolStripMenuItem.Name = "построитьГрафикToolStripMenuItem";
            this.построитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.построитьГрафикToolStripMenuItem.Text = "График";
            this.построитьГрафикToolStripMenuItem.Click += new System.EventHandler(this.построитьГрафикToolStripMenuItem_Click);
            // 
            // отчиститьГрафикToolStripMenuItem
            // 
            this.отчиститьГрафикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.алгоритм1ToolStripMenuItem,
            this.алгоритм2ToolStripMenuItem,
            this.алгоритм3ToolStripMenuItem,
            this.алгоритм4ToolStripMenuItem,
            this.алгоритм5ToolStripMenuItem,
            this.алгоритм6ToolStripMenuItem,
            this.алгоритм7ToolStripMenuItem,
            this.алгоритм8ToolStripMenuItem});
            this.отчиститьГрафикToolStripMenuItem.Name = "отчиститьГрафикToolStripMenuItem";
            this.отчиститьГрафикToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.отчиститьГрафикToolStripMenuItem.Text = "Построить";
            this.отчиститьГрафикToolStripMenuItem.Click += new System.EventHandler(this.отчиститьГрафикToolStripMenuItem_Click);
            // 
            // алгоритм1ToolStripMenuItem
            // 
            this.алгоритм1ToolStripMenuItem.Name = "алгоритм1ToolStripMenuItem";
            this.алгоритм1ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм1ToolStripMenuItem.Text = "Алгоритм 1";
            this.алгоритм1ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм1ToolStripMenuItem_Click);
            // 
            // алгоритм2ToolStripMenuItem
            // 
            this.алгоритм2ToolStripMenuItem.Name = "алгоритм2ToolStripMenuItem";
            this.алгоритм2ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм2ToolStripMenuItem.Text = "Алгоритм 2";
            this.алгоритм2ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм2ToolStripMenuItem_Click);
            // 
            // алгоритм3ToolStripMenuItem
            // 
            this.алгоритм3ToolStripMenuItem.Name = "алгоритм3ToolStripMenuItem";
            this.алгоритм3ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм3ToolStripMenuItem.Text = "Алгоритм 3";
            this.алгоритм3ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм3ToolStripMenuItem_Click);
            // 
            // алгоритм4ToolStripMenuItem
            // 
            this.алгоритм4ToolStripMenuItem.Name = "алгоритм4ToolStripMenuItem";
            this.алгоритм4ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм4ToolStripMenuItem.Text = "Алгоритм 4";
            this.алгоритм4ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм4ToolStripMenuItem_Click);
            // 
            // алгоритм5ToolStripMenuItem
            // 
            this.алгоритм5ToolStripMenuItem.Name = "алгоритм5ToolStripMenuItem";
            this.алгоритм5ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм5ToolStripMenuItem.Text = "Алгоритм 5";
            this.алгоритм5ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм5ToolStripMenuItem_Click);
            // 
            // алгоритм6ToolStripMenuItem
            // 
            this.алгоритм6ToolStripMenuItem.Name = "алгоритм6ToolStripMenuItem";
            this.алгоритм6ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм6ToolStripMenuItem.Text = "Алгоритм 6";
            this.алгоритм6ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм6ToolStripMenuItem_Click);
            // 
            // алгоритм7ToolStripMenuItem
            // 
            this.алгоритм7ToolStripMenuItem.Name = "алгоритм7ToolStripMenuItem";
            this.алгоритм7ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм7ToolStripMenuItem.Text = "Алгоритм 7";
            this.алгоритм7ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм7ToolStripMenuItem_Click);
            // 
            // алгоритм8ToolStripMenuItem
            // 
            this.алгоритм8ToolStripMenuItem.Name = "алгоритм8ToolStripMenuItem";
            this.алгоритм8ToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.алгоритм8ToolStripMenuItem.Text = "Алгоритм 8";
            this.алгоритм8ToolStripMenuItem.Click += new System.EventHandler(this.алгоритм8ToolStripMenuItem_Click);
            // 
            // отчиститьToolStripMenuItem
            // 
            this.отчиститьToolStripMenuItem.Name = "отчиститьToolStripMenuItem";
            this.отчиститьToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.отчиститьToolStripMenuItem.Text = "Отчистить";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 671);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "График";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_iterations);
            this.groupBox2.Controls.Add(this.textBox_n);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(851, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // textBox_iterations
            // 
            this.textBox_iterations.Location = new System.Drawing.Point(189, 101);
            this.textBox_iterations.Name = "textBox_iterations";
            this.textBox_iterations.Size = new System.Drawing.Size(100, 31);
            this.textBox_iterations.TabIndex = 3;
            // 
            // textBox_n
            // 
            this.textBox_n.Location = new System.Drawing.Point(78, 42);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(100, 31);
            this.textBox_n.TabIndex = 2;
            this.textBox_n.TextChanged += new System.EventHandler(this.textBox_n_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "к-во итераций";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "n =";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1158, 724);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratory Work No.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem построитьГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчиститьГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_iterations;
        private System.Windows.Forms.TextBox textBox_n;
        private System.Windows.Forms.ToolStripMenuItem алгоритм2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритм8ToolStripMenuItem;
    }
}

