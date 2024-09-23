﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Lab1
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private ToolTip toolTip1 = new ToolTip();

        private void отчиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
        }
        private void ClearGraphic()
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
        }

        private void textBox_n_TextChanged(object sender, EventArgs e)
        {

        }

        private void алгоритм1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg1.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i+1 ,time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, (double)i/700000);
            }



        } 

        private void алгоритм2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg2.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
            }
        }

        private void алгоритм3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg3.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
            }
        }

        private void алгоритм4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg4.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, (double)i/800000); //при большом n врет
            }
        }

        private void алгоритм5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg5.BubbleSort, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, Math.Pow(i, 2) / 800000);  //делим для улучшения демонстрации графика
            }            
        }

        private void алгоритм6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg6.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, 0.00005d);
            }
        }

        private void алгоритм7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGraphic();
            double[] time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg7.Run, Convert.ToInt32(textBox_iterations.Text));

            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, 0.00005d);
            }
        }

        private void алгоритм8ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Program.OnOffSwitch(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Program.OnOffSwitch(false);
        }
    }
}
