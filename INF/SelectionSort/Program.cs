using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] toSort = { 10, 82, 3, 92, 87, 7, 19 };
            SelectionSort(ref toSort);

            foreach (int num in toSort)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey(true);
        }

        public static void SelectionSort(ref int[] toSort)
        {
            for (int i = 0; i < toSort.Length - 1; i++)
            {
                int smallestIndex = -1;
                for (int j = i; j < toSort.Length; j++)
                {
                    if (smallestIndex == -1 || toSort[j] < toSort[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }

                int tmp = toSort[smallestIndex];
                toSort[smallestIndex] = toSort[i];
                toSort[i] = tmp;
            }
        }
    }
}
