using System;
using System.Threading;

namespace Lab1
{
    public class RecPow
    {
        public static void Run(int[] array, int x)
        {
            foreach (long number in array)
            {
                long result = Pow(x, number);
            }
        }
        
        public static int[] RunSteps(int n, int x, Action<int, int> updateChartCallback, CancellationToken token)
        {
            var totalSteps = new int[n];
            int stepCounter = 0;
            for (int i = 0; i < totalSteps.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token); 
                }
                var currentSteps = PowSteps(x, i, ref stepCounter);
                updateChartCallback(i, currentSteps);
                totalSteps[i] = currentSteps;
            }

            return totalSteps;
        }
        public static long Pow(long x, long n)
        {
            if (n == 0)
                return 1;

            if (n % 2 == 0)
            {
                long halfPow = Pow(x, n / 2);
                return halfPow * halfPow;
            }
            else
            {
                return x * Pow(x, n - 1);
            }
        }
        
        public static int PowSteps(int x, int n, ref int stepCounter)
        {
            stepCounter++;
            if (n == 0)
                return 1;

            if (n % 2 == 0)
            {
                stepCounter++;
                int halfPow = PowSteps(x, n / 2, ref stepCounter);
                stepCounter++;
                return halfPow * halfPow;
            }
            else
            {
                stepCounter++;
                return x * PowSteps(x, n - 1, ref stepCounter);
            }
        }
    }
}