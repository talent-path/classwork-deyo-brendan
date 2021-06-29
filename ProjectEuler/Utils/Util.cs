using System;
using System.Collections.Generic;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            if (num < 2) return false;
            bool prime = true;
            BigInteger sqrRoot = GetRoot(num);
            if (num % 2 == 0)
            {
                return num == 2;
            }
            for (BigInteger check = 3; check <= sqrRoot; check += 2)
            {
                if (num % check == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }

        public static bool IntIsPrime(int num)
        {
            if (num < 2)
                return false;

            int root = GetRootInteger(num);

            if (num % 2 == 0 && num != 2)
                return false;

            for (int i = 3; i <= root; i+=2)
            {
                if (num % i == 0)
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

        public static bool IsTruncatable(BigInteger num)
        {
            int lengthOfNum = num.ToString().Length;

            bool checkNum = false;

            //num = 3797
            BigInteger onesDigit = num % 10;

            BigInteger lastDigit = int.Parse(num.ToString().Substring(0, 1));

            if (!IsPrime(onesDigit) || !IsPrime(lastDigit))
            {
                return false;
            }
            else
            {
                // right to left
                for(int i = lengthOfNum; i >= 1; i--)
                {
                    string debug = num.ToString().Substring(0, i);
                    checkNum = IsPrime(BigInteger.Parse(num.ToString().Substring(0, i)));

                    if (!checkNum)
                    {
                        return false;
                        
                    }
                }

                // left to right

                for (int i = 1; i < lengthOfNum; i++)
                {
                    checkNum = IsPrime(BigInteger.Parse(num.ToString().Substring(i)));

                    if (!checkNum)
                    {
                        return false;

                    }
                }
            }
            return true;
        }

        public static BigInteger FlipNumber(BigInteger num)
        {
            BigInteger reverse = 0;
            while (num > 0)
            {
                BigInteger remainder = num % 10;
                reverse = (reverse * 10) + remainder;
                num /= 10;
            }

            return reverse;
        }

        public static List<int> GenerateDivisors(int num)
        {
            List<int> toReturn = new List<int>();

            int rootNum = GetRootInteger(num);

            for(int i = 1; i <= rootNum; i++)
            {
                if (num % i == 0)
                {
                    toReturn.Add(i);

                    //if num == 9, dont add two 3's

                    if (i * i != num)
                        toReturn.Add(num / i);
                }
            }

            return toReturn;

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