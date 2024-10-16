using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

namespace Lab1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static int[] RandomArray(int size,CancellationToken token)
        {
            int[] randomArray = new int[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                if (token.IsCancellationRequested) 
                {
                    throw new OperationCanceledException(token);
                }
                randomArray[i] = random.Next();
            }

            return randomArray;
        }
        public static int[][] MakeMassives(int n,CancellationToken token)
        {
            int[][] arrays = new int[n][];
            for (int j = 0; j < n; j++)
            {
                if (token.IsCancellationRequested) 
                {
                    throw new OperationCanceledException(token);
                }
                arrays[j] = new int[j];
                arrays[j] = RandomArray(j,token);
            }            
            return arrays;
        }
        public static int[,] RandomMatrix(int size,CancellationToken token)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (token.IsCancellationRequested) 
                    {
                        throw new OperationCanceledException(token);
                    }
                    matrix[i, j] = random.Next();
                }
            }
            return matrix;
        }
        public static int[][,] MakeMatrices(int n,CancellationToken token)
        {
            int[][,] matrices = new int[n][,];
            for (int i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested) 
                {
                    throw new OperationCanceledException(token);
                }
                matrices[i] = RandomMatrix(i,token);
            }            
            return matrices;
        }
        public static double[] Measure(int[][] arrays, Action<int[]> operation, int iterations, Action<int, double> updateChartCallback,CancellationToken token)
        {
            double[] time = new double[arrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < arrays.Length; i++)
            {
                if (token.IsCancellationRequested) 
                {
                    throw new OperationCanceledException(token);
                }
                double totalTime = 0;

                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();

                    operation(arrays[i]);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }

                time[i] = totalTime / iterations;

                updateChartCallback(i, time[i]);
            }

            return !choice ? time : FixArtefact(time);
        }
        
        public static double[] Measure(int[][] arrays, Action<int[],int> operation, int iterations, Action<int, double> updateChartCallback, int x,CancellationToken token)
        {
            double[] time = new double[arrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < arrays.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token); 
                }
                
                double totalTime = 0;

                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();

                    operation(arrays[i],x);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }

                time[i] = totalTime / iterations;
                
                updateChartCallback(i, time[i]);
            }

            return !choice ? time : FixArtefact(time);
        }
        public static double[] MeasureMatrixes(int[][,] aMatrixArrays ,int[][,] bMatrixArrays, Action<int[,], int[,]> operation, int iterations, Action<int, double> updateChartCallback,CancellationToken token)
        {
            double[] time = new double[aMatrixArrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < aMatrixArrays.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token);
                }
                
                double totalTime = 0;

                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();

                    operation(aMatrixArrays[i], bMatrixArrays[i]);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }

                time[i] = totalTime / iterations;
                
                updateChartCallback(i, time[i]);
            }

            return !choice ? time : FixArtefact(time);
        }
        public static double[] FixArtefact(double[] time)
        {            
            for (int i = 1; i<time.Length-1; i++)
            {
                if (time[i] > time[i+1]*1.2)
                {
                    time[i] = (time[i-1]+time[i+1])/2;
                }
            }
            return time;
        }
        public static bool choice = false;
        public static void OnOffSwitch(bool buttonChoice)
        {
            if (buttonChoice)
                choice = true;
            else 
                choice = false;
        }
    }
}
