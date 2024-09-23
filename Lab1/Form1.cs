using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            algorithmComboBox.Items.AddRange(new string[]
            {
                "постоянная функция", "сумма элементов", "произведение элементов",
                "полином", "Bubble sort", "Quick sort", "Timsort","SimplePow","RecPow","QuickPow","ClassikQuickPow"
            });
            this.Controls.Add(algorithmComboBox);
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            buildChartButton.Text = "Построить график";
            buildChartButton.Click += BuildChartButton_Click;
            this.Controls.Add(buildChartButton);
            
            
            this.Controls.Add(progressBar);
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            
        }

        private async void BuildChartButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = algorithmComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм.");
                return;
            }

            ClearGraphic();
            progressBar.Value = 0;
            int iterations = Convert.ToInt32(textBox_iterations.Text);

            await Task.Run(() =>
            {
                double[] time;
                switch (selectedIndex)
                {
                    case 0:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg1.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 1:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg2.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 2:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg3.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 3:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg4.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 4:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg5.BubbleSort,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, Math.Pow(i, 2) / 800000);  //делим для улучшения демонстрации графика
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }    
                        }));

                        break;
                    
                    case 5:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg6.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));

                        break;
                    case 6:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg7.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));

                        break;
                    case 7:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), SimplePow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        

                        break;
                    case 8:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), RecPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 9:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), QuickPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    
                    case 10:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), ClassikQuickPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 700000);
                                progressBar.Value = (i + 1) * 100 / time.Length;
                            }
                        }));
                        break;
                    default:
                        MessageBox.Show("Алгоритм не найден.");
                        return;
                }

            });
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
