namespace Uebung5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                int j = arr[i];
            }

            foreach (int tmpVal in arr)
            {
                // ....
            }

            int[,] tab = new int[2, 3];
            int[,] tab2 = { { 10, 20 }, { 30, 40 }, { 50, 60 } };

            for(int row = 0; row < tab2.GetLength(0); row++)
            {
                for(int col = 0; col < tab2.GetLength(1); col++)
                {
                    int tmpVal = tab2[row, col];
                }
            }

            foreach(int tmpVal in tab2)
            {

            }

            int[][] tab3 = new int[3][];
            tab3[0] = new int[5];
            tab3[1] = new int[] { 1, 3, 4 };
            tab3[2] = new int[1];

            for (int row = 0; row < tab3.Length; row++)
            {
                for (int col = 0; col < tab3[row].Length; col++)
                {
                    int tmpVal = tab2[row, col];
                }
            }

            foreach(int[] tempArr in tab3)
            {
                foreach(int tmpVal in tempArr)
                {

                }
            }
        }
    }
}
