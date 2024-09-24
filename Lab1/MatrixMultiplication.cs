namespace Lab1
{
    public static class MatrixMultiplication
    {
        public static void Run(int[,] aMatrix, int[,] bMatrix,int n)
        {
            int rA = aMatrix.GetLength(0);
            int cA = aMatrix.GetLength(1);
            int rB = bMatrix.GetLength(0);
            int cB = bMatrix.GetLength(1);

            int temp = 0;
            int[,] result = new int[rA, cB];

            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    temp = 0;
                    for (int k = 0; k < cA; k++)
                    {
                        temp += aMatrix[i, k] * bMatrix[k, j];
                    }

                    result[i, j] = temp;
                }
            }
        }
    }
}