using System;
using Utils;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentAnswer = 2520;

            int toReturn = 0;

            bool notFound = true;

            while (notFound)
            {
                int count = 0;

                for (int i = 1; i < 20; i++)
                {
                    if (currentAnswer % i != 0)
                    {
                        notFound = true;
                        break;
                    }
                    else
                        count++;
                }

                if (count == 20)
                    notFound = false;

            }

            Console.WriteLine(currentAnswer);
        }
    }
}
