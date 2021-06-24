using System;
using System.Collections.Generic;

namespace Problem26
{
    class Program
    {

        //A unit fraction contains 1 in the numerator.The decimal representation of the unit fractions with denominators 2 to 10 are given:

        //1/2	= 	0.5
        //1/3	= 	0.(3)
        //1/4	= 	0.25
        //1/5	= 	0.2
        //1/6	= 	0.1(6)
        //1/7	= 	0.(142857)
        //1/8	= 	0.125
        //1/9	= 	0.(1)
        //1/10	= 	0.1
        //Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.It can be seen that 1/7 has a 6-digit recurring cycle.

        //Find the value of d< 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

        static void Main(string[] args)
        {
            int maxCycle = 0;

            int maxDenom = 0;

            for (int i = 2; i < 1000; i++)
            {
                int cycleLength = FindRecurringCycle(i);

                if (cycleLength > maxCycle)
                {
                    maxDenom = i;
                    maxCycle = cycleLength;
                }
            }

            Console.WriteLine(maxDenom);
        }

        public static int FindRecurringCycle(int denom)
        {
            //return reccuring cycle count. Ex) 1 / 7, return 6

            int remainder = 1;

            HashSet<int> seenDigits = new HashSet<int>();

            List<int> allDigits = new List<int>();

            while (remainder != 0)
            {
                int fraction = remainder / denom;

                remainder = (remainder - denom * fraction) * 10;

                allDigits.Add(remainder);

                if (!seenDigits.Add(remainder))
                {
                    break;
                }

            }

            // length = 6
            // a b c d e c
            // 0 1 2 3 4 5
            // Index Of C = 2
            // length - Index Of C - 1

            return allDigits.Count - allDigits.IndexOf(allDigits[allDigits.Count - 1]) - 1;

        }
    }
}
