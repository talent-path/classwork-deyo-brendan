using System;
using System.Numerics;

namespace BigRational
{
    /// <summary>
    /// This class is meant to precisely represent rational fractions and perform
    /// math/comparison operations.
    /// </summary>
    public class BigRational
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public BigRational(BigInteger num, BigInteger denom)
        {

            BigInteger a, b, temp;

            //todo: reduce both by the greatest common denominator
            // (hint: look for Euclid's algorithm)

            if (denom < 0)
            {
                num *= -1;
                denom *= -1;
            }

            if (num > denom)
            {
                a = num;
                b = denom;
            }
            else
            {
                b = num;
                a = denom; 
            }

            while (a != 0 && b!= 0)
            {
                temp = a;
                a = b;
                b = temp % b;
            }

            Numerator = num / a;
            Denominator = denom / a;
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        //public BigInteger FindGCD(BigInteger left, BigInteger right)
        //{
        //    BigInteger toReturn = 0;
        //    BigInteger temp = 0;
        //    BigInteger max = left;
        //    BigInteger min = right;

        //    if (left < right)
        //    {
        //        max = right;
        //        min = left;
        //    }
        //    else
        //    {
        //        while (max != 0 && min != 0)
        //        {

        //        }
        //    }
        //}

        public static BigRational operator * (BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        //TODO: add remaining arithmetic operators (-, /, +, %)

        public static BigRational operator - (BigRational left, BigRational right)
        {
            BigInteger findGCD = left.Denominator * right.Denominator;

            BigInteger x = left.Numerator * right.Denominator;
            BigInteger y = left.Denominator * right.Numerator;

            return new BigRational(x - y, findGCD);
        }

        public static BigRational operator + (BigRational left, BigRational right)
        {
            BigInteger findGCD = left.Denominator * right.Denominator;

            BigInteger x = left.Numerator * right.Denominator;
            BigInteger y = left.Denominator * right.Numerator;

            return new BigRational(x + y, findGCD);
        }

        public static BigRational operator / (BigRational left, BigRational right)
        {
            BigInteger flipRightNum = right.Denominator;
            BigInteger flipRightDenom = right.Numerator;

            BigInteger findGCD = left.Denominator * flipRightDenom;

            return new BigRational(left.Numerator * flipRightNum, findGCD);
        }

        public static BigRational operator % (BigRational left, BigRational right)
        {
            BigInteger findGCD = left.Denominator * right.Denominator;

            BigInteger x = left.Numerator * right.Denominator;
            BigInteger y = left.Denominator * right.Numerator;

            return new BigRational(x % y, findGCD);
        }

        public static bool operator > (BigRational left, BigRational right)
        {
            //  a     c
            //  -  >  -
            //  b     d

            // ad < bc

            return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
        }

        public static bool operator < (BigRational left, BigRational right)
        {

            //  a     c
            //  -  <  -
            //  b     d

            // ad < bc

            return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
        }

        public static bool operator <= (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator <= right.Numerator * left.Denominator;
        }

        public static bool operator >= (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator >= right.Numerator * left.Denominator;
        }

        public static bool operator == (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator == right.Numerator * left.Denominator;
        }

        public static bool operator != (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator != right.Numerator * left.Denominator;
        }

        //TODO: add remaining comparison operators (>=, <=, ==, !=)



    }
}
