using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                "RecPow","QuickPow","ClassikQuickPow", "Умножение матриц", "TreeSort", "CocktailSort", "BitonicSort"
            });
            this.Controls.Add(algorithmComboBox);
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            algorithmComboBox.SelectedIndexChanged += AlgorithmComboBox_SelectedIndexChanged;
            xTextBox.Visible = false;
            powTime_Button.Visible = false;
            powSteps_Button.Visible = false;
            
            buildChartButton.Text = "Построить график";
            buildChartButton.Click += BuildChartButton_Click;
            this.Controls.Add(buildChartButton);
            
            stopButton.Text = "Завершить построение графика";
            stopButton.Click += StopButton_Click;
            this.Controls.Add(stopButton);
            
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
            
            powTime_Button.CheckedChanged += PowTimeButton_CheckedChanged;
        }
        private async Task DrawLine(double[] time, Func<int, double> factor)
        {
            for (int i = 0; i < time.Length; i++)
            {
                if (cancelDrawing) break;

                pointsBatch.Add(new DataPoint(i + 1, factor(i)));
                
                if (pointsBatch.Count == batchSize || i == time.Length - 1)
                {
                    Invoke((Action)(() =>
                    {
                        foreach (var point in pointsBatch)
                        {
                            this.chart1.Series[1].Points.Add(point);
                        }
                        chart1.ChartAreas[0].RecalculateAxesScale();
                    }));

                    pointsBatch.Clear();

                    await Task.Delay(1); 
                }
            }
        }
        private async Task DrawLineWithAutoCoefficient(double[] time, Func<int, double> growthFunction)
        {
            // Рассчитываем коэффициент на основе времени и функции роста
            double coefficient = CalculateCoefficient(time, growthFunction);
    
            await DrawLine(time, i => growthFunction(i) / coefficient);
        }
        private double CalculateCoefficient(double[] time, Func<int, double> growthFunction)
        {
            int maxIndex = time.Length - 1;
            double maxTime = time[maxIndex]; // Максимальное время выполнения

            // Рассчитываем коэффициент на основе роста алгоритма и максимального времени
            double coefficient = growthFunction(maxIndex) / maxTime;

            return coefficient;
        }
        
        private bool cancelDrawing;
        private CancellationTokenSource cancellationTokenSource;
        private List<DataPoint> pointsBatch = new List<DataPoint>();
        private int batchSize;
        private void UpdateBatchSize(int n)
        {
            // Пример: устанавливаем batchSize как n / 10, минимум 100, максимум 10000
            batchSize = Math.Max(10, Math.Min(10000, n / 100));
        }

        private async void BuildChartButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = algorithmComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм.");
                return;
            }
            
            if (!IsValidNumber(textBox_n.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное значение для n.");
                return;
            }
    
            if (textBox_iterations.Visible &&!IsValidNumber(textBox_iterations.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное значение для количества итераций.");
                return;
            }
            
            if (xTextBox.Visible && !IsValidNumber(xTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное значение для x.");
                return;
            }
            
            pointsBatch.Clear();
            UpdateBatchSize(Convert.ToInt32(textBox_n.Text));
            buildChartButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;   
            
            Invoke((Action)ClearGraphic);
            try
            {
                await Task.Run(async () =>
            {
                double[] time;
                int[] steps;
                Action<int, double> updateChart = (index, currentTime) =>
                {
                    if (cancelDrawing) return;
                    
                    pointsBatch.Add(new DataPoint(index + 1, currentTime));
                    
                    if (pointsBatch.Count >= batchSize || index == Convert.ToInt32(textBox_n.Text) - 1)
                    {
                        Invoke((Action)(() =>
                        {
                            foreach (var point in pointsBatch)
                            {
                                this.chart1.Series[0].Points.Add(point);
                            }
                            
                            pointsBatch.Clear();
                            this.chart1.ChartAreas[0].RecalculateAxesScale();
                        }));
                    }
                };

                Action<int, int> updateStepsChart = (index, currentSteps) =>
                {
                    if (cancelDrawing) return;
                    
                    pointsBatch.Add(new DataPoint(index + 1, currentSteps));

                    if (pointsBatch.Count >= batchSize || index == Convert.ToInt32(textBox_n.Text) - 1)
                    {
                        Invoke((Action)(() =>
                        {
                            foreach (var point in pointsBatch)
                            {
                                this.chart1.Series[0].Points.Add(point);
                            }

                            pointsBatch.Clear();
                            this.chart1.ChartAreas[0].RecalculateAxesScale();
                        }));
                    }
                };


                switch (selectedIndex)
                {
                    case 0://постоянная функция
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg1.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i => i); 
                        break;
                    
                    case 1://сложение
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg2.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i => i); 
                        break;
                    
                    case 2://умножение
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg3.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i => i); 
                        break;
                    
                    case 3://полином
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg4.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i => i); 
                        break;
                    
                    case 4://BubbleSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg5.BubbleSort,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i => Math.Pow(i, 2));
                        break;
                    
                    case 5: //QuickSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg6.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>i*Math.Log(i,2));
                        break;
                    
                    case 6://TimSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Alg7.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>i*Math.Log(i,2));

                        break;
                    case 7://SimplePow
                        if (powTime_Button.Checked == false)
                        {
                            steps = SimplePow.RunSteps(Convert.ToInt32(textBox_n.Text), Convert.ToInt32(xTextBox.Text),
                                updateStepsChart, cancellationToken);
                        }
                        else
                        {
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), SimplePow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLineWithAutoCoefficient(time, i => i);
                        }
                        break;
                    
                    case 8://RecPow
                        if (powTime_Button.Checked == false)
                        {
                            steps = RecPow.RunSteps(Convert.ToInt32(textBox_n.Text), Convert.ToInt32(xTextBox.Text),
                                updateStepsChart, cancellationToken);
                        }
                        else
                        {
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), RecPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLineWithAutoCoefficient(time, i => i);
                        }
                        break;
                    
                    case 9://QuickPow
                        if (powTime_Button.Checked == false)
                        {
                            steps = QuickPow.RunSteps(Convert.ToInt32(textBox_n.Text), Convert.ToInt32(xTextBox.Text),
                                updateStepsChart, cancellationToken);
                        }
                        else
                        {
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), QuickPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLineWithAutoCoefficient(time, i => i*Math.Log(i,2));
                        }
                        break;
                    
                    case 10://ClassikQuickPow
                        if (powTime_Button.Checked == false)
                        {
                            steps = ClassikQuickPow.RunSteps(Convert.ToInt32(textBox_n.Text), Convert.ToInt32(xTextBox.Text),
                                updateStepsChart, cancellationToken);
                        }
                        else
                        {
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), ClassikQuickPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLineWithAutoCoefficient(time, i => i*Math.Log(i,2));
                        }
                        break;
                    
                    case 11://MatrixMultiplication
                        time = Program.MeasureMatrixes(Program.MakeMatrices(Convert.ToInt32(textBox_n.Text),cancellationToken), 
                            Program.MakeMatrices(Convert.ToInt32(textBox_n.Text),cancellationToken), MatrixMultiplication.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>Math.Pow(i, 3));
                        break;
                    
                    case 12: //TreeSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), Treesort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>i*Math.Log(i,2));
                        break;
                    
                    case 13: //CocktailSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), CocktailSort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>Math.Pow(i,2));
                        break;
                    case 14: //BitonicSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text),cancellationToken), BitonicSort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLineWithAutoCoefficient(time, i =>i*Math.Log(i,2));
                        break;
                    
                    default:
                        MessageBox.Show("Алгоритм не найден.");
                        return;
                }
            },cancellationToken);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Построение графика остановлено.");
            }
            finally
            {
                buildChartButton.Enabled = true;
                cancelDrawing = false;
                cancellationTokenSource = null;
            }
            
        }
        
        private bool IsValidNumber(string input)
        {
            return int.TryParse(input, out int value) && value > 0;
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
            cancelDrawing = false;
            buildChartButton.Enabled = true;
        }


        
        private void AlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algorithmComboBox.SelectedItem.ToString() == "SimplePow" || 
                algorithmComboBox.SelectedItem.ToString() == "RecPow"|| 
                algorithmComboBox.SelectedItem.ToString() == "QuickPow"|| 
                algorithmComboBox.SelectedItem.ToString() == "ClassikQuickPow")
            {
                xTextBox.Visible = true;
                powSteps_Button.Visible = true;
                powTime_Button.Visible = true;
                textBox_iterations.Visible = false;
                groupBox3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
            }
            else
            {
                xTextBox.Visible = false;
                powSteps_Button.Visible = false;
                powTime_Button.Visible = false;
                textBox_iterations.Visible = true;
                groupBox3.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
            }
        }
        
        private void PowTimeButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox_iterations.Visible = !powTime_Button.Checked;
            groupBox3.Visible = !powTime_Button.Checked;
            radioButton1.Visible = !powTime_Button.Checked;
            radioButton2.Visible = !powTime_Button.Checked;
            textBox_iterations.Visible = powTime_Button.Checked;
            groupBox3.Visible = powTime_Button.Checked;
            radioButton1.Visible = powTime_Button.Checked;
            radioButton2.Visible = powTime_Button.Checked;
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
