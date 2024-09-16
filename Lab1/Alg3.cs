using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Alg3
    {
        
        public static void Run(int[] array)
        {
            long composition = 1;

            foreach (int i in array)
            {
                composition *= i;
            }
        }
    }
}
