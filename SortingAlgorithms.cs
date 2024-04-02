using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortAlgorithms.Interfaces;

namespace SortingAlgorithms
{
    public class SortingAlgorithms
    {
        //Алгоритм сортування бульбашкою

        public class BubbleSorter : ISorter
        {

            public void Sort(int[] array)
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);

                        }
                    }
                }
            }

        }

        // Алгоритм сортування вставкою

        public class InsertionSorter : ISorter
        {
            public void Sort(int[] array)
            {
                int n = array.Length;
                for (int i = 1; i < n; ++i)
                {
                    int key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                    array[j + 1] = key;
                }
            }
        }

        // Алгоритм сортування вибором

        public class SelectionSorter : ISorter
        {
            public void Sort(int[] array)
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                }
            }
        }


        // Алгоритм швидкого сортування

        public class QuickSorter : ISorter
        {
            public void Sort(int[] array)
            {
                if (array == null || array.Length == 0)
                    return;

                Sort(array, 0, array.Length - 1);
            }

            private void Sort(int[] array, int minIndex, int maxIndex)
            {
                if (minIndex < maxIndex)
                {
                    int pi = Partition(array, minIndex, maxIndex);
                    Sort(array, minIndex, pi - 1);
                    Sort(array, pi + 1, maxIndex);
                }
            }

            private int Partition(int[] array, int minIndex, int maxIndex)
            {
                int pivot = array[maxIndex];
                int i = minIndex - 1;
                for (int j = minIndex; j < maxIndex; j++)
                {
                    if (array[j] < pivot)
                    {
                        i++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                }
                (array[i + 1], array[maxIndex]) = (array[maxIndex], array[i + 1]);
                return i + 1;
            }
        }
    }
}

