using System;
using System.Threading;

namespace Lab1
{
    public class QuickPow
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
        public static long Pow(int x, int n) //обычные
        {
            long result = 1;
            long baseValue = x;
            
            if (n % 2 == 1) result = baseValue;
            
            while (n != 0)
            {
                n /= 2;
                baseValue *= baseValue;
                if (n % 2 == 1) result *= baseValue;
            }
            return result;
        }

        public static int PowSteps(int x, int n) //пошаговые
        {
            int stepCounter = 0;
            long result = 1;
            long baseValue = x;

            if (n % 2 == 1)
            {
                result = baseValue;
                stepCounter++;
            }

            while (n != 0)
            {
                stepCounter++;
                n /= 2;
                stepCounter++;

                baseValue *= baseValue;
                stepCounter++; 

                if (n % 2 == 1)
                {
                    stepCounter++;
                    result *= baseValue;
                    stepCounter++;  
                }
            }

            return stepCounter;
        }
    }
}