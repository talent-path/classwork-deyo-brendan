using System;
using Utils;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool solved = false;
            int a = 0;
            int b = 0;
            int c = 0;
            int sum = 1000;

            while (!solved)
            {
                for (a = 1; a < sum / 4; a++)
                {
                    for (b = a; b < sum / 2; b++)
                    {
                        c = sum - a - b;
                        if (a * a + b * b == c * c)
                        {
                            solved = true;
                            break;
                        }
                    }

                    if (solved && (a + b + c == sum))
                    {
                        Console.WriteLine("ANSWER");
                        Console.WriteLine("a: " + a);
                        Console.WriteLine("b: " + b);
                        Console.WriteLine("c: " + c);
                        Console.WriteLine(a * b * c);
                    }

                }
            }
        }
    }
}
