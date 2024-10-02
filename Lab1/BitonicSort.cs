using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class BitonicSort
    {

        public static void Run(int[] array)
        {
            BitonicMergeSort.BitonicSort(array, 0, array.Length, 1);
        }

        public class BitonicMergeSort
        {
            static void Swap<T>(ref T leftHandSide, ref T rightHandSide)
            {
                T temp;
                temp = leftHandSide;
                leftHandSide = rightHandSide;
                rightHandSide = temp;
            }
            public static void CompareAndSwap(int[] array, int i, int j, int direction)
            {
                int k;

                k = array[i] > array[j] ? 1 : 0;


                if (direction == k)
                {

                    Swap(ref array[i], ref array[j]);
                }
            }


            public static void BitonicMerge(int[] array, int low, int count, int direction)
            {
                if (count > 1)
                {
                    int k = count / 2;
                    for (int i = low; i < low + k; i++)
                    {
                        CompareAndSwap(array, i, i + k, direction);
                    }
                    BitonicMerge(array, low, k, direction);
                    BitonicMerge(array, low + k, k, direction);
                }
            }


            public static void BitonicSort(int[] array, int low, int count, int direction)
            {
                if (count > 1)
                {
                    int k = count / 2;


                    BitonicSort(array, low, k, 1);


                    BitonicSort(array, low + k, k, 0);


                    BitonicMerge(array, low, count, direction);
                }
            }
        }
    }
}