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
        public static void Run(int[] array, int x)
        {
            Simple(array,x);
        }
        public static void Simple(int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int temp = 1;
                for (int j = 0; j < x; j++)
                {
                    temp *= array[i];
                }
            }
        }
    }
}
