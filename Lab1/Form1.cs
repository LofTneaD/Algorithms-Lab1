﻿using System;
using System.Collections.Generic;
using System.Drawing;
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

        }
        private async Task DrawLine(double[] time, Func<int, double> factor)
        {
            const int batchSize = 10;
            List<DataPoint> pointsBatch = new List<DataPoint>(batchSize);

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
        
        private async Task DrawLine(double[] time, double factor)
        {
            const int batchSize = 10;
            List<DataPoint> pointsBatch = new List<DataPoint>(batchSize);

            for (int i = 0; i < time.Length; i++)
            {
                if (cancelDrawing) break;

                pointsBatch.Add(new DataPoint(i + 1, i/factor));
                
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
        
        private bool cancelDrawing;
        private CancellationTokenSource cancellationTokenSource;
        private async void BuildChartButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = algorithmComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм.");
                return;
            }
            
            buildChartButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource(); // Создаем источник токенов отмены
            var cancellationToken = cancellationTokenSource.Token;   
            
            Invoke((Action)ClearGraphic);
            try
            {
                await Task.Run(async () =>
            {
                double[] time;
                int[] steps;
                Action<int, double> updateChart = (index, elapsedTime) =>
                {
                    if (cancelDrawing) return;
                    Invoke((Action)(() =>
                    {
                        
                        this.chart1.Series[0].Points.AddXY(index + 1, elapsedTime);
                        this.chart1.ChartAreas[0].RecalculateAxesScale();
                    }));
                    
                };
                Action<int, int> updateStepsChart = (index, elapsedTime) =>
                {
                    if (cancelDrawing) return;

                    Invoke((Action)(() =>
                    {
                        
                        this.chart1.Series[0].Points.AddXY(index + 1, elapsedTime);
                        this.chart1.ChartAreas[0].RecalculateAxesScale();
                    }));
                    
                };

                switch (selectedIndex)
                {
                    case 0:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg1.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, 2700000);
                        break;
                    
                    case 1:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg2.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, 2300000);
                        break;
                    
                    case 2:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg3.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, 700000);
                        break;
                    
                    case 3:
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg4.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, 3500000);
                        break;
                    
                    case 4://BubbleSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg5.BubbleSort,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => Math.Pow(i, 2) / 3200000);
                        break;
                    
                    case 5: //QuickSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg6.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => i*Math.Log(i,2)/40000);
                        break;
                    
                    case 6://TimSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Alg7.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => i*Math.Log(i,2)/450000);

                        break;
                    case 7://SimplePow
                        if (powTime_Button.Checked == false)
                        {
                            steps = SimplePow.RunSteps(Convert.ToInt32(textBox_n.Text), Convert.ToInt32(xTextBox.Text),
                                updateStepsChart, cancellationToken);
                        }
                        else
                        {
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), SimplePow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLine(time, i => i*1000);
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
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), RecPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLine(time, i => i*Math.Log(i,2)/18000);
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
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), QuickPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLine(time, i => i*Math.Log(i,2)/60000);
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
                            time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), ClassikQuickPow.Run,
                                Convert.ToInt32(textBox_iterations.Text), updateChart,Convert.ToInt32(xTextBox.Text),cancellationToken);
                            await DrawLine(time, i => i*Math.Log(i,2)/50000);
                        }
                        break;
                    
                    case 11://MatrixMultiplication
                        time = Program.MeasureMatrixes(Program.MakeMatrices(Convert.ToInt32(textBox_n.Text)), 
                            Program.MakeMatrices(Convert.ToInt32(textBox_n.Text)), MatrixMultiplication.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => Math.Pow(i, 3) / 550000);
                        break;
                    
                    case 12: //TreeSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), Treesort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => i*Math.Log(i,2)/30000);
                        break;
                    
                    case 13: //CocktailSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), CocktailSort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => Math.Pow(i,2)/9000000);
                        break;
                    case 14: //BitonicSort
                        time = Program.Measure(Program.MakeMassives(Convert.ToInt32(textBox_n.Text)), BitonicSort.Run,
                            Convert.ToInt32(textBox_iterations.Text), updateChart,cancellationToken);
                        await DrawLine(time, i => i*Math.Log(i,2)/120000);
                        break;
                    
                    default:
                        MessageBox.Show("Алгоритм не найден.");
                        return;
                }
            });
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
            }
            else
            {
                xTextBox.Visible = false;
                powSteps_Button.Visible = false;
                powTime_Button.Visible = false;
                textBox_iterations.Visible = true;
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
