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
    }
}