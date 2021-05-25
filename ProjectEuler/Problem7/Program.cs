using System;
using Utils;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        { 
            int toReturn = 0;

            for (int i = 2, count = 0; ; i*=i)
            {
                if (Util.IsPrime(i))
                    count++;
                if (count == 10001)
                    toReturn = i;
            }

            Console.WriteLine(int.MaxValue);

        }
    }
}
