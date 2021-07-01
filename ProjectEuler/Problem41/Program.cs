using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;
using System.Linq;

namespace Problem41
{
    class Program
    {

        //We shall say that an n-digit number is pandigital if it makes use of all the digits
        //1 to n exactly once.For example, 2143 is a 4-digit pandigital and is also prime.

        //What is the largest n-digit pandigital prime that exists?

        static void Main(string[] args)
        {
            List<BigInteger> primeNums = new List<BigInteger>();
            List<BigInteger> pandigitalNums = new List<BigInteger>();
            List<string> permutations = new List<string>();
            List<string> digits = new List<string> { "9", "8", "7", "6", "5", "4", "3", "2", "1" };

            for (int remove = 0; remove < 8; remove++)
            {
                Util.GeneratePermutations(permutations, "", digits.Skip(remove).ToList());

                foreach (string i in permutations)
                {
                    if (Util.IsPrime(BigInteger.Parse(i)))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }

                permutations.Clear();
            }

            //primeNums.Sort();

            //Console.WriteLine(primeNums[0]);
        }
    }
}
