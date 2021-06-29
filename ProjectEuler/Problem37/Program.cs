using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;

namespace Problem37
{
    class Program
    {

        //The number 3797 has an interesting property.Being prime itself,
        //it is possible to continuously remove digits from left to right, and remain prime at each stage:
        //3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

        //Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

        //NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
        static void Main(string[] args)
        {
            BigInteger result = 0;

            bool checkTruncatable = false;

            List<BigInteger> primeNums = new List<BigInteger>();

            BigInteger num = 8;

            while(primeNums.Count < 11)
            { 
                checkTruncatable = Util.IsTruncatable(num);
                if (checkTruncatable)
                    primeNums.Add(num);
                num++;
            }

            foreach(BigInteger number in primeNums)
            {
                result += number;
            }

            Console.WriteLine(result);
       
        }
    }
}
