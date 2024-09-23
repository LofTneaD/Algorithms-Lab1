using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Alg9
    {
        public static void Run(int x, int n)
        {
            MatrixMultiplication(n);
        }

        public static int[,] MatrixMultiplication(int n)
        {
            int[,] matrixA = new int[n, n];
            int[,] matrixB = new int[n, n];
            int[,] resMatrix = new int[n, n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j<n; j++)
                {
                    matrixA[i, j] = random.Next(0, 100);
                    matrixB[i, j] = random.Next(0, 100);
                }
            }

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        resMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return resMatrix;
        }
    }
}
