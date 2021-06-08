using System;
using System.IO;
using System.Numerics;

namespace Problem13
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger result = new BigInteger();

            string line = null;

            StreamReader reader = new StreamReader("../../../nums.txt");

            while((line = reader.ReadLine()) != null)
            {
                result += BigInteger.Parse(line);
            }

            reader.Close();

            Console.WriteLine(result);
        }
    }
}
