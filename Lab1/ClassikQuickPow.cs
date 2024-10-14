using System;
using System.Threading;

namespace Lab1
{
    public class ClassikQuickPow
    {
        public static void Run(int[] array, int x)
        {
            foreach (int number in array)
            {
                long result = Pow(x, number);
            }
        }
        public static int[] RunSteps(int n, int x, Action<int, int> updateChartCallback, CancellationToken token)
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
            long baseValue = x;

            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    result *= baseValue;
                    n -= 1;
                }
                else
                {
                    baseValue *= baseValue;
                    n /= 2;
                }
            }
            return result;
        }
        public static int PowSteps(int x, int n)
        {
            long result = 1;
            long baseValue = x;
            int stepCounter = 0;

            while (n > 0)
            {
                stepCounter++;

                if (n % 2 != 0)
                {
                    result *= baseValue;
                    n -= 1;
                    stepCounter+=3;
                }
                else
                {
                    baseValue *= baseValue;
                    n /= 2;
                    stepCounter+=3;
                }
            }

            return stepCounter;
        }
    }
}