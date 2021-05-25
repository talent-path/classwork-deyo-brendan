using System;
using System.Numerics;
using Utils;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger toSolve = 600851475143;

            BigInteger max = 0;

            BigInteger biggestLowFactor = int.MinValue;

            BigInteger root = Util.GetRoot(toSolve);

            for (BigInteger i = 1; i < root; i++)
            {
                if (root % i == 0)
                {
                    max = root / i;

                    if (Util.IsPrime(max))
                    {
                        Console.WriteLine(max);
                        break;
                    }

                    if (Util.IsPrime(i))
                    {
                        biggestLowFactor = i;
                    }
                }
            }

        }
    }
}
