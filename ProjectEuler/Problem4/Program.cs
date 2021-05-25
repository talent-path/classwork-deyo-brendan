using System;
using Utils;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            int calc = 0;
            int temp = 0;
            int max = 0;

            for (int i = 999; i > 0; i--)
            {
                for (int j = 999; j > 0; j--)
                {
                    calc = i * j;
                    if (Util.IsPalindrome(calc))
                    {
                        temp = calc;
                        if (temp > max)
                            max = temp;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
