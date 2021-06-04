using System;
using System.Collections.Generic;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            BigInteger root = GetRoot(num);

            if (num % 2 == 0 && num != 2)
                return false;

            for (BigInteger i = 3; i <= root; i+=2)
            {
                if (root % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IntIsPrime(int num)
        {
            int root = GetRootInteger(num);

            if (num % 2 == 0 && num != 2)
                return false;

            for (int i = 3; i <= root; i+=2)
            {
                if (root % i == 0)
                    return false;
            }

            return true;
        }

        public static bool IsPrime(List<int> primes, int num)
        {
            foreach(int prime in primes)
            {
                if (GetRootInteger(num) < prime)
                    break;
                if (num % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }


        public static BigInteger GetRoot(BigInteger num)
        {
            BigInteger root = 0;

            for (BigInteger i = 1; i < num; i++)
            {
                if ((i * i) > num)
                {
                    root = i - 1;
                    break;
                }
            }

            return root;
        }

        public static int GetRootInteger(int num)
        {
            int root = 0;

            for (int i = 1; i < num; i++)
            {
                if ((i * i) > num)
                {
                    root = i - 1;
                    break;
                }
            }

            return root;
        }

        //public static int[] GenerateTriangulars(int num)
        //{

        //}

        public static bool IsPalindrome(int num)
        {
            String toCompare = num.ToString();

            int length = toCompare.Length;

            for (int i = 0; i < length; i++)
            {
                if (toCompare[i] != toCompare[length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}