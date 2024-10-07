namespace Lab1
{
    public class ClassikQuickPow
    {
        public static void Run(int[] array, int x)
        {
            int stepCounter = 0;
            foreach (int number in array)
            {
                long result = StepsPow(x, number, ref stepCounter);
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

        public static long StepsPow(int x, int n, ref int stepCounter)
        {
            long result = 1;
            long baseValue = x;

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

            return result;
        }
    }
}