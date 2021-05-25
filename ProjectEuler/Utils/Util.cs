using System;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            BigInteger root = GetRoot(num);

            for (BigInteger i = 2; i < root; i++)
            {
                if (root % i == 0)
                    return false;
            }
            return false;
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