using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger sum = 2;

            List<int> primes = new List<int>();

            for (int i = 3; i < 2000000; i+=2)
            {
                if (Util.IsPrime(primes, i))
                {
                    primes.Add(i);
                    sum += i;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
