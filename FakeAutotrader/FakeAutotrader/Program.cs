using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FakeAutotrader
{

    //DESCRIPTION

    //Fake Autotrader

    //As a user, I should be able to enter a list of stock symbols to watch(just pressing enter to indicate I'm done with a blank line).

    //As a user, I should be able to see periodic updates to prices (once a minute for each monitored stock).

    //As a user, whenever a stock crosses above the median price observed so far, I should get a message to sell that stock.

    //As a user, whenever a stock crosses below the median price observed so far, I should get a message to buy that stock.

    class Program
    {
        static HttpClient _client = new HttpClient();

        static Mutex _mutex = new Mutex();

        static List<Task> _tasks = new List<Task>();

        static List<string> _list = new List<string>();

        static bool _finished = false;

        static int _count = 0;

        static void Main(string[] args)
        {
            List<string> userSymbols = new List<string>();

            string line = null;

            Console.WriteLine("****Enter stock symbols separated with the enter key****");

            while (!_finished)
            {
                line = Console.ReadLine().ToLower();
                if (line == "")
                    break;
                else
                    userSymbols.Add(line);
            }

            for (int i = 0; i < userSymbols.Count; i++)
            {
                var jobToAdd = Task.Factory.StartNew(() => Dispatcher(userSymbols[i]));
                _tasks.Add(jobToAdd);
            }

        }


        static double GetMedianStockValue(double[] prices)
        {
            double toReturn = 0;

            Array.Sort(prices);

            if (prices.Length % 2 == 0)
                toReturn = ((double)prices[prices.Length / 2] + (double)prices[prices.Length / 2 - 1]) / 2;
            else
                toReturn = (double)prices[prices.Length / 2];

            return toReturn;
        }

        static async Task Dispatcher(string userSymbol)
        {
            while (_count < 5000)
            {
                try
                {
                    string requestURL = "https://finnhub.io/api/v1/quote?symbol=" + userSymbol + "&token=c2t7gc2ad3i9opckklf0";

                    HttpResponseMessage responseMessage =
                        await _client.GetAsync(requestURL);

                    responseMessage.EnsureSuccessStatusCode();

                    string message = await responseMessage.Content.ReadAsStringAsync();

                    _mutex.WaitOne();
                    Console.WriteLine(message);
                    _mutex.ReleaseMutex();

                    //TODO: figure out regular expression

                    _count++;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
