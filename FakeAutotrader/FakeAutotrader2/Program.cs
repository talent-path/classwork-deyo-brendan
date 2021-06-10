using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace FakeAutotrader2
{
    class Program
    {
        static Dictionary<string, List<double>> _priceValues = new Dictionary<string, List<double>>();

        static Mutex _mutex = new Mutex();

        static void Main(string[] args)
        {
            List<string> userSymbols = GetStocksFromUser();

            List<Task> tasks = new List<Task>();

            foreach(string symbol in userSymbols)
            {
                _priceValues.Add(symbol, new List<double>());
                var jobToAdd = Task.Factory.StartNew(() => GetStockValues(symbol)).Unwrap();
                tasks.Add(jobToAdd);
            }

            Task.WaitAll(tasks.ToArray());
        }

        static async Task GetStockValues(string symbol)
        {
            int count = 0;

            HttpClient client = new HttpClient();

            string requestURL = "https://finnhub.io/api/v1/quote?symbol="+symbol+"&token=c2t7gc2ad3i9opckklf0";

            while (count < 10000)
            {
                HttpResponseMessage responseMessage =
                    await client.GetAsync(requestURL);

                responseMessage.EnsureSuccessStatusCode();

                string priceData = await responseMessage.Content.ReadAsStringAsync();

                double price = ExtractPrice(priceData);

                Console.WriteLine("Symbol: " + symbol + " | Price : " + price);

                _mutex.WaitOne();

                _priceValues[symbol].Add(price);

                double medianPrice = GetMedianPrice(_priceValues[symbol]);

                _mutex.ReleaseMutex();

                if (price > medianPrice)
                    Console.WriteLine(symbol + " price is higher than median value. Recommended to sell...");
                else if (price < medianPrice)
                    Console.WriteLine(symbol + " price is lower than median value. Recommended to buy...");

                Console.WriteLine();

                await Task.Delay(5000);

                count++;
            }
        }

        private static double GetMedianPrice(List<double> prices)
        {
            return prices.OrderBy((price) => price).Skip(prices.Count / 2).First();
        }

        private static double ExtractPrice(string priceData)
        {
            int indexOfPrice = priceData.IndexOf("\"c\"") + 4;

            int indexOfComma = priceData.IndexOf(',', indexOfPrice);

            string price = priceData.Substring(indexOfPrice, indexOfComma - indexOfPrice); ;

            return double.Parse(price);
        }

        private static List<string> GetStocksFromUser()
        {
            string line = null;

            bool finished = false;

            List<string> toReturn = new List<string>();

            Console.WriteLine("****Enter stock symbols separated with the enter key****");

            while (!finished)
            {
                line = Console.ReadLine().ToLower();
                if (line == "")
                {
                    finished = true;
                }
                else
                    toReturn.Add(line.ToUpper());
            }

            return toReturn;
        }
    }
}
