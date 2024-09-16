using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Alg7
    {
        const int RUN = 32; // Минимальный размер руна
        public static void Run(int[] array)
        {
            TimSort(array, array.Length);
        }

        static void TimSort(int[] array, int n)
        {
            // Сортируем подмассивы размером RUN с помощью сортировки вставками
            for (int i = 0; i < n; i += RUN)
            {
                InsertionSort(array, i, Math.Min(i + RUN - 1, n - 1));
            }

            // Объединяем отсортированные руны с помощью сортировки слиянием
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                        Merge(array, left, mid, right);
                }
            }
        }
        // Сортировка вставками
        static void InsertionSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = array[i];
                int j = i - 1;

                while (j >= left && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        // Слияние двух подмассивов
        static void Merge(int[] array, int left, int mid, int right)
        {
            // Создаем временные массивы для левой и правой половин
            int len1 = mid - left + 1;
            int len2 = right - mid;
            int[] leftArray = new int[len1];
            int[] rightArray = new int[len2];

            for (int x = 0; x < len1; x++)
                leftArray[x] = array[left + x];
            for (int x = 0; x < len2; x++)
                rightArray[x] = array[mid + 1 + x];

            // Индексы для левой, правой половин и основного массива
            int i = 0, j = 0, k = left;

            while (i < len1 && j < len2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Копируем оставшиеся элементы
            while (i < len1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < len2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
