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

    //API KEY & URL: https://finnhub.io/api/v1/quote?symbol=GME&token=c2t7gc2ad3i9opckklf0

    class Program
    {
        static HttpClient _client = new HttpClient();

        static Mutex _mutex = new Mutex();

        static List<Task> _tasks = new List<Task>();

        static Regex _regex = new Regex(@"(?<={""c"":)[^,]+");

        static List<string> _list = new List<string>();

        static Dictionary<string, List<double>> _priceValues = new Dictionary<string, List<double>>();

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
                {
                    _finished = true;
                }
                else
                    userSymbols.Add(line.ToUpper());
            }

            for (int i = 0; i < userSymbols.Count; i++)
            {
                var jobToAdd = (Task.Factory.StartNew(() => Dispatcher(userSymbols[i])).Unwrap());
                _tasks.Add(jobToAdd);
            }

            Task.WaitAll(_tasks.ToArray());

        }


        static double GetMedianStockValue(List<double> prices)
        {
            double toReturn = 0;

            prices.Sort();

            if (prices.Count % 2 == 0)
                toReturn = (prices[prices.Count / 2] + prices[prices.Count / 2 - 1]) / 2;
            else
                toReturn = prices[prices.Count / 2];

            return toReturn;
        }

        static async Task CheckSymbolValues(string userSymbol)
        {
            while (_count < 10000)
            {
                try
                {
                    string requestURL = "https://finnhub.io/api/v1/quote?symbol=" + userSymbol + "&token=c2t7gc2ad3i9opckklf0";

                    HttpResponseMessage responseMessage =
                        await _client.GetAsync(requestURL);

                    responseMessage.EnsureSuccessStatusCode();

                    string message = await responseMessage.Content.ReadAsStringAsync();

                    int indexOfPrice = message.IndexOf("\"c\"") + 4;

                    int indexOfComma = message.IndexOf(',', indexOfPrice);

                    string price = message.Substring(indexOfPrice, indexOfComma - indexOfPrice);;

                    double symbolValue = double.Parse(price);

                    _mutex.WaitOne();

                    List<double> currStockPrices = _priceValues[userSymbol];

                    

                    _mutex.ReleaseMutex();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                _count++;

                await Task.Delay(5000);

            }
        }
    }
}
