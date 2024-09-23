using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    internal class Alg8
    {
        public static void Run(int x, int n)
        {
            SimplePow(x, n);
            //RecPow(x, n);
        }
        public static int SimplePow(int x, int n)
        {
            int f = 1;
            int k = 1;
            while (k < n)
            {
                f *= x;
                k += 1;
            }
            Console.WriteLine(f);
            return f;
        }
        public static int RecPow(int x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                int f = RecPow(x, n / 2);

                f *= f;

                if (n % 2 == 1)
                {
                    f *= x;
                }

                return f;
            }
        }

        public static int QuickPow(int x, int n)
        {
            int f = 1;
            int c = x;
            int k = n;

            if (k%2 == 1)
            {
                f = c;
            }

            else if(k%2 == 0)
            {
                f = 1;
            }

            while (k!=0) 
            {
                k = k / 2;
                c = c * c;
                if (k % 2 == 1)
                {
                    f = f * c;
                }
            }

            return f;
        }

        public static int QuickPow1(int x, int n)
        {
            int f = 1;
            int c = x;
            int k = n;

            while (k!=0)
            {
                if (k%2 == 0)
                {
                    c = c * c;
                    k = k / 2;
                }

                else if(k%2 == 1)
                {
                    f = f * c;
                    k = k - 1;
                }
            }

            return f;
        }

    }
}
