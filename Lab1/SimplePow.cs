using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    internal class SimplePow
    {
        public static void Run(int[] array, int x) //обычные
        {
            for (int i = 0; i < array.Length; i++)
            {
                long temp = 1;
                for (int j = 0; j < array[i]; j++)
                {
                    temp *= x;
                }
            }
        }
        public static int[] StepsRun(int[] array, int x) //пошаговые
        {
            int[] steps = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                long temp = 1;
                for (int j = 0; j < array[i]; j++)
                {
                    temp *= x;
                    steps[i] += 1;
                }
            }
            return steps;
        }
    }
}
