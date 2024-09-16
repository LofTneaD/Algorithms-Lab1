using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Alg2
    {        
        public static void Run(int[] array)
        {
            long sum = 0;

            foreach (int i in array)
            { 
                sum += i;
            }
        }
    }
}
