namespace Lab1
{
    public class QuickPow
    {
        public static void Run(int[] array, int x)
        {
            int stepCounter = 0;
            foreach (int number in array)
            {
                long result = StepsPow(x, number, ref stepCounter);
            }
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

        public static long StepsPow(int x, int n, ref int stepCounter) //пошаговые
        {
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

            return result;
        }
    }
}