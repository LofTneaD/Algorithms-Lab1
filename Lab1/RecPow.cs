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
            for (int i = 0; i < totalSteps.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token); // Обрабатываем отмену
                }

                int stepCounter = 0;
                var currentSteps = PowSteps(x, i, ref stepCounter); // Получаем количество шагов
                updateChartCallback(i, currentSteps); // Обновляем график
                totalSteps[i] = currentSteps; // Сохраняем количество шагов
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
            stepCounter++; // Считаем шаг за текущий вызов

            if (n == 0)
            {
                return stepCounter; // Если степень 0, возвращаем текущий счетчик шагов
            }

            if (n % 2 == 0)
            {
                stepCounter++; // Шаг за деление на 2
                PowSteps(x, n / 2, ref stepCounter); // Рекурсивный вызов для n / 2
                stepCounter++; // Шаг за умножение результатов
            }
            else
            {
                stepCounter++; // Шаг за уменьшение степени на 1
                PowSteps(x, n - 1, ref stepCounter); // Рекурсивный вызов для n - 1
            }

            return stepCounter; // Возвращаем количество шагов
        }
    }
}