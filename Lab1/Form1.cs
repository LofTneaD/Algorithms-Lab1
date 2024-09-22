using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            algorithmListBox.Items.AddRange(new string[]
            {
                "Алгоритм 1", "Алгоритм 2", "Алгоритм 3",
                "Алгоритм 4", "Алгоритм 5", "Алгоритм 6", "Алгоритм 7"
            });
            this.Controls.Add(algorithmListBox);
            buildChartButton.Text = "Построить график";
            buildChartButton.Click += BuildChartButton_Click;
            this.Controls.Add(buildChartButton);

        }
        
        private void BuildChartButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = algorithmListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм.");
                return;
            }

            ClearGraphic();

            double[] time;
            switch (selectedIndex)
            {
                case 0:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg1.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 1:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg2.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 2:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg3.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 3:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg4.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 4:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg5.BubbleSort, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 5:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg6.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                case 6:
                    time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg7.Run, Convert.ToInt32(textBox_iterations.Text));
                    break;
                default:
                    MessageBox.Show("Алгоритм не найден.");
                    return;
            }
            
            for (int i = 0; i < time.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ClearGraphic()
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
        }
        private void textBox_n_TextChanged(object sender, EventArgs e)
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
