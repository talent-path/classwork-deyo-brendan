using System;
using System.IO;

namespace Problem22
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../names.txt");

            string textNames = reader.ReadToEnd().Replace("/", "").Replace("\"", "");

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            long result = 0;

            string[] arr = textNames.Split(',');

            Array.Sort(arr);

            for (int i = 1; i <= arr.Length; i++)
            {
                int score = 0;

                foreach (var eachChar in arr[i - 1].ToCharArray())
                {
                    score += (Array.IndexOf(alpha, eachChar) + 1);
                }

                score *= i;

                result += score;
            }
            Console.WriteLine(result);
        }
    }
}
