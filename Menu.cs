using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingAlgorithms;
using SortAlgorithms.Interfaces;
using static SortingAlgorithms.SortingAlgorithms;

namespace SortAlgorithms
{
    public class MenuManager
    {
        public static int[] flattenedArray = new int [0];
        public static void SortingMenu()
        {
            

            //Реалізація меню за допомогою оператора switch
            
                Console.WriteLine("1 - Ввести новий масив");
                Console.WriteLine("2 - Відсортувати методом бульбашки");
                Console.WriteLine("3 - Відсортувати методом вставки");
                Console.WriteLine("4 - Відсортувати методом вибору");
                Console.WriteLine("5 - Відсортувати методом швидкого сортування");
                Console.WriteLine("6 - Завершити програму");


                Console.WriteLine("Вибір: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        InputArray();
                        SortingMenu();
                    break;

                    case 2:
                        if (flattenedArray.Length > 0)
                        {
                            Console.WriteLine("\nСортування бульбашкою:");
                            int[] bubbleSortedArray = (int[])flattenedArray.Clone();
                            ISorter sorter = new BubbleSorter();
                            sorter.Sort(bubbleSortedArray);
                            PrintArray(bubbleSortedArray);
                        }
                        else
                        {
                            Console.WriteLine("Ви не ввели масив. Спробуйте повторно ввести");
                            InputArray();
                        }
                        break;
                case 3:
                    if (flattenedArray.Length > 0)
                    {
                        Console.WriteLine("\nСортування вставкою:");
                        int[] insertionSortedArray = (int[])flattenedArray.Clone();
                        ISorter sorter = new InsertionSorter();
                        sorter.Sort(insertionSortedArray);
                        PrintArray(insertionSortedArray);
                    }
                    else
                    {
                        Console.WriteLine("Ви не ввели масив. Спробуйте повторно ввести");
                        InputArray();
                    }
                    break;
                case 4:
                    if (flattenedArray.Length > 0)
                    {
                        Console.WriteLine("\nСортування вибором:");
                        int[] selectionSortedArray = (int[])flattenedArray.Clone();
                        ISorter sorter = new SelectionSorter();
                        sorter.Sort(selectionSortedArray);
                        PrintArray(selectionSortedArray);
                    }
                    else
                    {
                        Console.WriteLine("Ви не ввели масив. Спробуйте повторно ввести");
                        InputArray();
                    }
                    break;
                case 5:
                    if (flattenedArray.Length > 0)
                    {
                        Console.WriteLine("\nШвидке сортування:");
                        int[] quickSortedArray = (int[])flattenedArray.Clone();
                        ISorter sorter = new QuickSorter();
                        sorter.Sort(quickSortedArray);
                        PrintArray(quickSortedArray);
                    }
                    else
                    {
                        Console.WriteLine("Ви не ввели масив. Спробуйте повторно ввести");
                        InputArray();
                    }
                    break;
                case 6:
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Виберіть одну опцію серед наявних:");
                        SortingMenu();
                        break;
                }
                // Метод для виведення масива в консоль
                static void PrintArray(int[] array)
                {
                    foreach (var item in array)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine(); 
                }
            }
        
        //Введення масиву та перетворення його в одновимірний масив
        public static void InputArray()
        {
            Console.WriteLine("Введіть розмір масиву (рядки x стовпці):");
            Console.Write("Рядки: ");
            int rows;
            while (true) { 
                try
                {
                    rows = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть ціле число");
                    Console.Write("Рядки: ");
                    continue;
                }             
            }

            Console.Write("Стовпці: ");
            int cols;
            while (true)
            {
                try
                {
                    cols = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть ціле число");
                    Console.Write("Стовпці: ");
                    continue;
                }
            }

            int[,] array = new int[rows, cols];

            Console.WriteLine("Введіть елементи масиву:");

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Рядок [{i + 1}]: ");
                for (int j = 0; j < cols; j++)
                {

                    array[i, j] = int.Parse(Console.ReadLine());

                }

            }

            // Виведення двовимірного масиву
            Console.WriteLine("\nВведений двовимірний масив:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Перетворення двовимірного масиву в одновимірний
            flattenedArray = new int[rows * cols];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flattenedArray[index++] = array[i, j];
                }
            }
        }
    } 
}
