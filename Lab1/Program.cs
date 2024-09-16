using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            /*double[] time = ChoiceAlg();
            
            int[] number = new int[time.Length];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i+1;
            }*/
        }

        public static int[] Random(int size)
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
            for (int i = 0; i < n; i++)
            {
                arrays[i] = new int[i];
                arrays[i] = Random(i);
            }
            return arrays;
        }

        /*public static double[] ChoiceAlg()
        {
            int size = 100;
            int iterations = 5;
            double[] time = null;

            Console.WriteLine("Выберите алгоритм");
            switch (Console.ReadLine())
            {
                case "1":
                    time = Measure(Random(size), Alg1.Run, iterations);
                    break;
            }
            return time;
        }*/

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

            return time;
        }       
    }
}
