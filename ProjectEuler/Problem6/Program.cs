using System;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            for (int i = 1; i <= 100; i++)
            {
                x += i;
                y += i * i;
            }

            int toReturn = x * x - y;

            Console.WriteLine(toReturn);

        }
    }
}
