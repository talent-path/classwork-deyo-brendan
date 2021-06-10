using System;
using System.Collections.Generic;
using Utils;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bPrimes = new List<int>();

            int maxLength = 0;

            (int, int) coefficients = (0, 0);

            for (int i = 2; i <= 1000; i++)
            {
                if (i == 41)
                {

                }
                if (Util.IntIsPrime(i))
                    bPrimes.Add(i);
            }

            foreach (int b in bPrimes)
            {
                for (int a = -999; a <= 999; a++)
                {
                    bool foundNonPrime = false;

                    int n = 0;

                    int count = 0;

                    while (!foundNonPrime)
                    {
                        if (Util.IntIsPrime((n * n) + (a * n) + b))
                        {
                            count++;
                        }
                        else
                        {
                            foundNonPrime = true;
                        }
                        n++;
                    }

                    if (count > maxLength)
                    {
                        Console.WriteLine("Count: " + count);
                        Console.WriteLine("A " + a);
                        Console.WriteLine("B " + b);
                        coefficients = (a, b);
                        maxLength = count;
                    }

                }
            }

            Console.WriteLine("Coefficient Product = " + (coefficients.Item1 * coefficients.Item2));

        }
    }
}
