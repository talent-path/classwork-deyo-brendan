using System;
using System.IO;

namespace Problem81
{
    class Program
    {

        //In the 5 by 5 matrix below, the minimal path sum from the top left to the bottom right, by only moving
        //to the right and down, is indicated in bold red and is equal to 2427.

        //Find the minimal path sum from the top left to the bottom right by only moving right and down in
        //matrix.txt(right click and "Save Link/Target As..."), a 31K text file containing an 80 by 80 matrix.

        static void Main(string[] args)
        {
            int[ , ] matrix = new int[80 , 80];

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
                        //int number;
                        //bool success = int.TryParse(numbers[i], out number);
                        //parseNums[i] = number;
                        parseNums[i] = int.Parse(numbers[i]);
                    }

                    for (int j = 0; j < 80; j++)
                    {
                        matrix[rowCount, j] = parseNums[j];
                    }

                    rowCount++;
                }

                Console.WriteLine(PathSum(matrix));

            }
        }

        static long PathSum(int[ , ] arr)
        {
            for(int i = 0; i < 80; i++)
            {
                for(int j = 0; j < 80; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if (i == 0)
                            arr[i, j] += arr[i, j - 1];
                        else if (j == 0)
                            arr[i, j] += arr[i - 1, j];
                        else
                            arr[i, j] += Math.Min(arr[i - 1, j], arr[i, j - 1]);
                    }
                }
            }

            return arr[79, 79];
        }

    }
}

