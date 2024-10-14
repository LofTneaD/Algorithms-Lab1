using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    internal class SimplePow
    {
        public static void Run(int[] array, int x)
        {
            foreach (int number in array)
            {
                long result = Pow(x, number);
            }
        }
        public static int[] RunSteps(int n, int x, Action<int, int> updateChartCallback, CancellationToken token) //пошаговые
        {
            var totalSteps = new int[n];
            for (int i = 0; i < totalSteps.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token); 
                }
                var currentSteps = PowSteps(x, i);
                updateChartCallback(i, currentSteps);
                totalSteps[i] = currentSteps;
            }
            return totalSteps;
        }

        public static long Pow(int x, int n)
        {
            long result = 1;
            
            for (int i = 0; i < n; i++)
            {
                result *= x;
            }

            return result;
        }
        
        public static int PowSteps(int x, int n)
        {
            int result = 1;
            
            for (int i = 0; i < n; i++)
            {
                result +=1;
            }

            return result;
        }
    }
}