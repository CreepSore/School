using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] toSort = {
                new int[] { 10, 82, 3, 92, 87, 7, 19 },
                new int[] { 0, 1, 2, 3, 4, 5, 6 },
                new int[] { 6, 5, 4, 3, 2, 1, 0 }
            };

            for (int i = 0; i < toSort.Length; i++)
            {
                BubbleSort(ref toSort[i]);

                foreach (int num in toSort[i])
                {
                    Console.WriteLine(num);
                }

                Console.WriteLine();
            }

            Console.ReadKey(true);
        }

        public static void BubbleSort(ref int[] toSort)
        {
            bool switched = true;
            do
            {
                switched = false;
                for (int i = 0; i < toSort.Length - 1; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        int tmp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = tmp;
                        switched = true;
                    }
                }
            } while (switched);
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
