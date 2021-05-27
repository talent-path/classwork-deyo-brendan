using System;
using System.Collections.Generic;
using System.IO;

namespace Nasdaq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * group data by year
             * get standard deviation for:
             * open
             * high
             * low
             * close
             * output should be a dictionary that maps from year to a list of
             * answers for that year
             * you could also make a class to hold the report for the year
             */

            Dictionary<int, List<DailyQuote>> quoteDict = new Dictionary<int, List<DailyQuote>>();

            Dictionary<int, List<decimal>> toPrint = new Dictionary<int, List<decimal>>();

            List<DailyQuote> quoteList = new List<DailyQuote>();

            List<decimal> deviations = new List<decimal>();

            string line = null;

            decimal[] openArr = new decimal[100];
            decimal[] highArr = new decimal[100];
            decimal[] lowArr = new decimal[100];
            decimal[] closeArr = new decimal[100];

            decimal openStdDev, highStdDev, lowStdDev, closeStdDev;

            using (StreamReader reader = new StreamReader("../../../HD.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    DailyQuote dailyQuote = new DailyQuote(line);
                    if (dailyQuote != null)
                        quoteList.Add(dailyQuote);
                }

            }

            for (int i = 0; i < quoteList.Count; i++)
            {
                if (quoteDict.ContainsKey(quoteList[i].Date.Year))
                {
                    quoteDict[quoteList[i].Date.Year].Add(quoteList[i]);
                }
                else
                {
                    List<DailyQuote> toAdd = new List<DailyQuote> { quoteList[i] };
                    quoteDict.Add(quoteList[i].Date.Year, toAdd);
                }
            }

            int count = 0;

            foreach (int num in quoteDict.Keys)
            {
                foreach (DailyQuote x in quoteDict[num])
                {
                    openArr.SetValue(x.Open, count);
                    highArr.SetValue(x.High, count);
                    lowArr.SetValue(x.Low, count);
                    closeArr.SetValue(x.Close, count);
                }

                openStdDev = GetStdDev(GetDev(openArr));
                highStdDev = GetStdDev(GetDev(highArr));
                lowStdDev = GetStdDev(GetDev(lowArr));
                closeStdDev = GetStdDev(GetDev(closeArr));

                deviations.Add(openStdDev);
                deviations.Add(highStdDev);
                deviations.Add(lowStdDev);
                deviations.Add(closeStdDev);

                toPrint.Add(num, deviations);
            }

            foreach (int num in toPrint.Keys)
            {
                Console.WriteLine();
                Console.WriteLine("===========================");

                Console.WriteLine("Year: " + num);
                Console.WriteLine("Open Deviation: " + toPrint[num][0]);
                Console.WriteLine("High Deviation: " + toPrint[num][1]);
                Console.WriteLine("Low Deviation: " + toPrint[num][2]);
                Console.WriteLine("Close Deviation: " + toPrint[num][3]);

                Console.WriteLine("===========================");
                Console.WriteLine();
            }
        }

        static List<decimal> StdDevList(decimal[] open, decimal[] high, decimal[] low, decimal[] close)
        {
            List<decimal> toReturn = new List<decimal>();
            decimal openStdDev = GetStdDev(GetDev(open));
            decimal highStdDev = GetStdDev(GetDev(high));
            decimal lowStdDev = GetStdDev(GetDev(low));
            decimal closeStdDev = GetStdDev(GetDev(close));

            toReturn.Add(openStdDev);
            toReturn.Add(highStdDev);
            toReturn.Add(lowStdDev);
            toReturn.Add(closeStdDev);

            return toReturn;
        }

        static decimal GetStdDev(decimal dev)
        {
            return (decimal) Math.Sqrt ((double)dev);
        }

        static decimal GetDev(decimal[] nums)
        {
            double toReturn = 0;

            if (nums.Length > 1)
            {
                double average = (double) GetAverage(nums);

                foreach (double num in nums)
                {
                    toReturn = Math.Pow(num - average, 2);
                }

                return (decimal) (toReturn / (nums.Length - 1));

            }
            else
                return 0;

        }

        static decimal GetAverage(decimal[] nums)
        {
            decimal toReturn = 0;

            if (nums.Length > 1)
            {
                foreach (decimal num in nums)
                {
                    toReturn += num;
                }
            }
            else
                toReturn += nums[0];

            return toReturn / nums.Length;

        }
    }
}
