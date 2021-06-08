using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem29
{
    class Program
    {
        static void Main(string[] args)
        {
            int minA = 2;
            int maxA = 100;

            int minB = 2;
            int maxB = 100;

            List<double> results = new List<double>();

            for (int i = minA; i <= maxA; i++)
            {
                for (int j = minB; j <= minB; j++)
                {
                    double power = Math.Pow(i, j);
                    results.Add(power);
                }
            }

            List<double> distinctPowers = results.Distinct().ToList();

            distinctPowers.Sort();

            Console.WriteLine(distinctPowers.Count());

        }
    }
}
