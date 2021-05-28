using System;
using System.Collections.Generic;

namespace MorningExercise
{
    class Program
    {

        static Random random = new Random();

        static void Main(string[] args)
        {
            List<double> sample = new List<double>();

            for (int i = 0; i < 10000; i++)
            {
                // hold uniformed distribution key, 0 - 1, used to generate standard distribution

                double uOne = random.NextDouble();
                double uTwo = random.NextDouble();

                while (uTwo == uOne)
                    uTwo = random.NextDouble();

                sample.Add(GetStandardDistribution(uOne, uTwo));

            }

            double mean = GetAverage(sample);

            Console.WriteLine("Mean: " + mean);

            double deviation = GetDeviation(sample);

            Console.WriteLine("Deviation: " + deviation);

        }


        static double GetDeviation(List<double> list)
        {
            double average = GetAverage(list);

            List<double> subtractMeanSquareResult = SubtractMeanSquareResult(list, average);

            double meanOfSquaredDifferences = GetAverage(subtractMeanSquareResult);

            return Math.Sqrt(meanOfSquaredDifferences);
        }

        static double GetAverage(List<double> list)
        {
            double toReturn = 0;

            foreach(double num in list)
            {
                toReturn += num;
            }

            return toReturn / list.Count;
        }

        static List<double> SubtractMeanSquareResult(List<double> list, double average)
        {
            List<double> toReturn = new List<double>();

            foreach (double num in list)
            {
                double toSquare = num - average;
                toReturn.Add(toSquare * toSquare);
            }

            return toReturn;
        }

        static double GetStandardDistribution(double uOne, double uTwo)
        {

            double theta = (2 * Math.PI) * uTwo;

            double rVar = Math.Sqrt((-2 * Math.Log(uOne)));

            double zZero = rVar * Math.Cos(theta);

            double zOne = rVar * Math.Sin(theta);

            int x = random.Next(0,  2);

            if (x == 0)
                return zZero;
            else
                return zOne;
        }
    }
}
