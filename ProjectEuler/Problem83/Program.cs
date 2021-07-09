using System;
using System.IO;

namespace Problem83
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = new int[80, 80];

            using (StreamReader reader = new StreamReader("../../../matrix.txt"))
            {
                string line = "";

                int rowCount = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(",");

                    int[] parseNums = new int[80];

                    for (int i = 0; i < 80; i++)
                    {
                        parseNums[i] = int.Parse(numbers[i]);
                    }

                    for (int j = 0; j < 80; j++)
                    {
                        matrix[rowCount, j] = parseNums[j];
                    }

                    rowCount++;
                }

                FourWayPathSum(matrix);

            }

            // 131 673 234 108 18
            // 203 96  355 80  284
            // 506 789 234 123 835
            // 78  912 174 12  124
            // 432 459 12  456 902

            static long FourWayPathSum(int[,] matrix)
            {
                long toReturn = 0;

                for (int row = 0; row < 80; row++)
                {
                    for (int col = 0; col < 80; col++)
                    {
                        if(row == 0 || col == 0)
                            toReturn += Math.Min(matrix[row + 1, col], matrix[row, col + 1]);
                        if(row == 79)

                    }
                }

                return toReturn;
            }
        }
    }   
}
