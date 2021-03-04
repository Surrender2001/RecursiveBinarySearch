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
                BinarySearch(array, searchedValue, first, middle - 1, ref count);
                BinarySearch(array, searchedValue, middle + 1, last, ref count);
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
            int[] a = { 1, 1, 1,1,1,1 };
            int count = 0;
            BinarySearch(a, 1, 0, a.Length - 1,ref count);
            
            
        }
    }
}
