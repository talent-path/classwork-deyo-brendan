using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            long[ , ] arr = new long[21, 21];

            long routeCount = 0;

            // 1x1 = 2
            // 2x2 = 6
            // 3x3 = 8

            // 1 1 1 1 0
            // 1 2 3 4 0
            // 1 3 6 10 0
            // 1 4 10 20 0
            // 0 0 0 0 0

            // RECURSION

            // routeCount = GetRecursivePaths(arr, 20, 20);

            // FIRST ANSWER

            for (int i = 0; i < 21; i++)
            {
                arr[0, i] = 1;
                arr[i, 0] = 1;
            }

            for (int i = 1; i < 21; i++)
            {
                for (int j = 1; j < 21; j++)
                {
                    arr[i, j] = (arr[i, j - 1] + arr[i - 1, j]);
                }
            }

            routeCount = arr[20, 20];

            Console.WriteLine(routeCount);
        }

        public static long GetRecursivePaths(long[,] arr, int row, int col)
        {
            long toReturn = 0;

            if (row == 0 || col == 0)
            {
                return 1;
            }
            
            if (arr[row, col] != 0)
            {
                toReturn = arr[row, col];
            }
            else
            {
                long countAbove = GetRecursivePaths(arr, row - 1, col);
                long countLeft = GetRecursivePaths(arr, row, col - 1);
                toReturn = countAbove + countLeft;
                arr[row, col] = toReturn;
            }

            return toReturn;
        }

    }
}
