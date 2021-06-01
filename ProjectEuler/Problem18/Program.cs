using System;
using System.Collections.Generic;
using System.IO;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../problem18.txt"))
            {
                string line = null;

                List<List<int>> numList = new List<List<int>>();

                while((line = reader.ReadLine()) != null)
                {
                    List<int> tempList = new List<int>();
                    string[] newArr = line.Split(' ');

                    foreach(string index in newArr)
                    {
                        int num = int.Parse(index);
                        tempList.Add(num);
                    }

                    numList.Add(tempList);

                }

                for(int i = 0; i < )

            }
        }
    }
}
