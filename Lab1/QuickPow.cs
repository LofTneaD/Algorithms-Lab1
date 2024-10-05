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
        public static long Pow(int x, int n)
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
    }
}