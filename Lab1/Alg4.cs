using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Alg4
    {
        public static void Run(int[] array)
        {
            double polynomial = 0;
            for (int i = array.Length - 1; i > 0; i--)
            {
                polynomial *= 1.5;
                polynomial = array[i - 1] + polynomial;
            }
        }
    }
}
