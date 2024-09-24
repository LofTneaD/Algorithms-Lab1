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
    }
}