namespace Lab1
{
    public class RecPow
    {
        public static void Run(int[] array, int x)
        {
            int stepCounter = 0;
            foreach (long number in array)
            {
                long result = StepsPow(x, number, ref stepCounter);
            }
        }
        public static long Pow(long x, long n) //обычные замеры
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

        public static long StepsPow(long x, long n, ref int stepCounter) //пошаговые
        {
            stepCounter++;
            if (n == 0)
                return 1;

            if (n % 2 == 0)
            {
                stepCounter++;
                long halfPow = StepsPow(x, n / 2, ref stepCounter);
                stepCounter++;
                return halfPow * halfPow;
            }
            else
            {
                stepCounter++;
                return x * StepsPow(x, n - 1, ref stepCounter);
            }
        }
    }
}