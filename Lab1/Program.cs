using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public static int[] RandomArray(int size)
        {
            int[] randomArray = new int[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                randomArray[i] = random.Next();
            }

            return randomArray;
        }
        public static int[][] MakeMassives(int n)
        {
            int[][] arrays = new int[n][];
            for (int j = 0; j < n; j++)
            {
                arrays[j] = new int[j];
                arrays[j] = RandomArray(j);
            }            
            return arrays;
        }
        public static int[,] RandomMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next();
                }
            }
            return matrix;
        }
        public static int[][,] MakeMatrices(int n)
        {
            int[][,] matrices = new int[n][,];
            for (int i = 0; i < n; i++)
            {
                matrices[i] = RandomMatrix(i);
            }            
            return matrices;
        }

        public static double[] Measure(int[][] arrays, Action<int[]> operation, int iterations)
        {
            double[] time = new double[arrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < arrays.Length; i++)
            {
                double totalTime = 0;

                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();

                    operation(arrays[i]);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }
                time[i] = totalTime / iterations;
            }         
            if (!choice)
                return time;
            else
                return FixArtefact(time);
        }
        public static double[] Measure(int[][] arrays, Action<int[], int> operation, int iterations, int x)
        {
            double[] time = new double[arrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < arrays.Length; i++)
            {
                double totalTime = 0;

                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();

                    operation(arrays[i],x);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }
                time[i] = totalTime / iterations;
            }         
            if (!choice)
                return time;
            else
                return FixArtefact(time);
        }
        
        public static double[] MeasureMatrix(int[][,] aMatrixArrays ,int[][,] bMatrixArrays, Action<int[,], int[,],int> operation, int iterations, int n)
        {
            double[] time = new double[aMatrixArrays.Length];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < aMatrixArrays.Length; i++)
            {
                double totalTime = 0;
                for (int j = 0; j < iterations; j++)
                {
                    stopwatch.Restart();
                        
                    operation(aMatrixArrays[i], bMatrixArrays[i], n);
                        
                    stopwatch.Stop();
                        
                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }
                time[i] = totalTime / iterations;
            }         
            if (!choice)
                return time;
            else
                return FixArtefact(time);
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
