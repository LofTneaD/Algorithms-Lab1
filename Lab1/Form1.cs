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
                "полином", "Bubble sort", "Quick sort", "Timsort","SimplePow",
                "RecPow","QuickPow","ClassikQuickPow", "Умножение матриц", "TreeSort", "CocktailSort"
            });
            this.Controls.Add(algorithmComboBox);
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            algorithmComboBox.SelectedIndexChanged += AlgorithmComboBox_SelectedIndexChanged;
            xTextBox.Visible = false;
            
            buildChartButton.Text = "Построить график";
            buildChartButton.Click += BuildChartButton_Click;
            this.Controls.Add(buildChartButton);
            
            textBox_n.Text = "Введите значение n";
            textBox_n.ForeColor = Color.Gray;

            textBox_n.GotFocus += RemoveText;
            textBox_n.LostFocus += AddText;
            
            xTextBox.Text = "Введите значение x";
            xTextBox.ForeColor = Color.Gray;

            xTextBox.GotFocus += xRemoveText;
            xTextBox.LostFocus += xAddText;
            
            textBox_iterations.Text = "Количество интераций";
            textBox_iterations.ForeColor = Color.Gray;

            textBox_iterations.GotFocus += interationsRemoveText;
            textBox_iterations.LostFocus += interationsAddText;

        }

        public static bool IsBuildingChart;
        private async void BuildChartButton_Click(object sender, EventArgs e)
        {
            if (IsBuildingChart)
            {
                MessageBox.Show("Построение графика уже выполняется, дождитесь завершения.");
                return;
            }

            int selectedIndex = algorithmComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм.");
                return;
            }

            IsBuildingChart = true;
            ClearGraphic();
            try
            {
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
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 1300000);
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
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 1100000);
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
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 610000);
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
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i / 200000);
                            }
                        }));
                        break;
                    
                    case 4://BubbleSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg5.BubbleSort,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, Math.Pow(i, 2) / 1400000); 
                            }    
                        }));

                        break;
                    
                    case 5: //QuickSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg6.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/140000);
                            }
                        }));

                        break;
                    case 6://TimSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg7.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/450000);
                            }
                        }));

                        break;
                    case 7://SimplePow
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), SimplePow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, (double)i*1000);
                            }
                        }));
                        

                        break;
                    case 8://RecPow
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), RecPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/10000);
                            }
                        }));
                        break;
                    
                    case 9://QuickPow
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), QuickPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/30000);
                            }
                        }));
                        break;
                    
                    case 10://ClassikQuickPow
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), ClassikQuickPow.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(xTextBox.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/30000);
                            }
                        }));
                        break;
                    
                    case 11:
                        time = Program.MeasureMatrix(Program.MakeMatrices(Convert.ToInt32(textBox_n.Text)), 
                            Program.MakeMatrices(Convert.ToInt32(textBox_n.Text)), MatrixMultiplication.Run,
                            Convert.ToInt32(textBox_iterations.Text), Convert.ToInt32(textBox_n.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, Math.Pow(i, 3) / 300000);
                            }
                        }));
                        break;
                    
                    case 12: //TreeSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Treesort.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, i*Math.Log(i,2)/30000);
                            }
                        }));
                        break;
                    case 13: //CocktailSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Treesort.Run,
                            Convert.ToInt32(textBox_iterations.Text));
                        Invoke((Action)(() =>
                        {
                            for (int i = 0; i < time.Length; i++)
                            {
                                this.chart1.Series[0].Points.AddXY(i + 1, time[i]);
                                this.chart1.Series[1].Points.AddXY(i + 1, Math.Pow(2,i)/30000);
                            }
                        }));
                        break;
                    
                    default:
                        MessageBox.Show("Алгоритм не найден.");
                        return;
                }
            });
            }
            finally
            {
                IsBuildingChart = false;
            }
            
        }
        
        private void AlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algorithmComboBox.SelectedItem.ToString() == "SimplePow" || 
                algorithmComboBox.SelectedItem.ToString() == "RecPow"|| 
                algorithmComboBox.SelectedItem.ToString() == "QuickPow"|| 
                algorithmComboBox.SelectedItem.ToString() == "ClassikQuickPow")
            {
                xTextBox.Visible = true;
            }
            else
            {
                xTextBox.Visible = false;
            }
        }
        
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Введите значение n")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Введите значение n";
                textBox.ForeColor = Color.Gray;
            }
        }
        
        private void xRemoveText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Введите значение x")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void xAddText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Введите значение x";
                textBox.ForeColor = Color.Gray;
            }
        }
        
        private void interationsRemoveText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Количество интераций")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void interationsAddText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Количество интераций";
                textBox.ForeColor = Color.Gray;
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
