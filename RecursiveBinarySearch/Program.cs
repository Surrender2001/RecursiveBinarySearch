using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveBinarySearch
{
    
    class Program
    {
        
        //метод для рекурсивного бинарного поиска
        static int BinarySearch(int[] array, int searchedValue, int first, int last,ref int count)
        {
            count++;
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            int middle = (first + last) / 2;
            //значение в средине подмассива
            int middleValue = array[middle];

            if (middleValue == searchedValue)
            {

                Console.WriteLine($"index= {middle}\tstep count= {count}");
                BinarySearch(array, searchedValue, first, middle - 1,ref count);
                BinarySearch(array, searchedValue, middle + 1, last,ref count);
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(array, searchedValue, first, middle - 1, ref count);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(array, searchedValue, middle + 1, last, ref count);
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("rows and columns: ");
            int rows = int.Parse(Console.ReadLine()), cols = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[rows,cols];
            int[] a = new int[cols];
            Console.WriteLine("to find key:");
            int key = int.Parse(Console.ReadLine()),count = 0;

            fillArray(ref arr);
            showArray(arr);
            sortArray(ref arr);
            Console.WriteLine("=================\nSorted:\n");
            showArray(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                copy(arr,ref a,i);
                Console.WriteLine($"{i} row:");
                if (BinarySearch(a, key, 0, a.Length - 1,ref count) == -1) Console.WriteLine("Not found");
                Console.WriteLine("=================");
                count = 0;
            }
      
            
        }

        private static void sortArray(ref int[,] arr)
        {
            int N = arr.GetLength(0), M = arr.GetLength(1),temp;
            for (int k = 0; k <= (N * M); k++)//колличество проходов
            {
                //в строках упорядочиваем
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M - 1; j++)
                    {
                        if (arr[i, j] > arr[i, j + 1])
                        {
                            temp = arr[i, j];
                            arr[i, j] = arr[i, j + 1];
                            arr[i, j + 1] = temp;
                        }
                    }
                }

            }
        }

        private static void copy(in int[,] arr, ref int[] a,int k)
        {
            for (int i = 0; i < arr.GetLength(1); i++) a[i] = arr[k, i];
        }

        private static void showArray(in int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j]+"\t");
                }
                Console.WriteLine();
            }




        }

        private static void fillArray(ref int[,] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(0);
                }
            }
        }
    }
}
