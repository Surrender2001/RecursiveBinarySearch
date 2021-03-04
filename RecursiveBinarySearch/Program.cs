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
        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
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

                Console.WriteLine("Index= "+middle);
                BinarySearch(array, searchedValue, first, middle - 1);
                BinarySearch(array, searchedValue, middle + 1, last);
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }


        static void Main(string[] args)
        {
            int[] a = { 1, 1, 1,1,1,1 };
            
            Console.WriteLine(BinarySearch(a, 1, 0, a.Length - 1));
        }
    }
}
