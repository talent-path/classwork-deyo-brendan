using System;
using System.Numerics;

namespace BigRational
{
    class Program
    {
        static void Main(string[] args)
        {
            BigRational twoThirds = new BigRational(2, 3);
            BigRational threeFourths = new BigRational(3, 4);
            BigRational nineTwelths = new BigRational(9, 12);

            BigRational sevenTenths = new BigRational(7, 10);
            BigRational oneHalf = new BigRational(1, 2);

            //BigRational toTest = new BigRational(270, 192);

            //Console.WriteLine(toTest);

            Console.WriteLine((sevenTenths * twoThirds) / nineTwelths);


            Console.WriteLine(oneHalf % twoThirds - oneHalf);


            Console.WriteLine(twoThirds / oneHalf * sevenTenths);

            // True
            Console.WriteLine(twoThirds <= threeFourths);


            // False
            Console.WriteLine(twoThirds >= threeFourths);


            // False
            Console.WriteLine(threeFourths == twoThirds);


            // True
            Console.WriteLine(threeFourths != twoThirds);


            // True
            Console.WriteLine(threeFourths == nineTwelths);


            Console.WriteLine(twoThirds + threeFourths);


            Console.WriteLine(sevenTenths % oneHalf);
        }
    }
}
