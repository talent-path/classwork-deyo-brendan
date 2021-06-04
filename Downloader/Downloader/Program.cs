using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Downloader
{
    class Program
    {
        static Regex urlRegex = new Regex(@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?");

        static Queue<string> queue = new Queue<string>();

        static HashSet<string> siteList = new HashSet<string>();

        static Mutex _queueLock = new Mutex();

        static string _inputUrl;

        static int _count = 0;

        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            _inputUrl = "https://moz.com/top500";

            queue.Enqueue(_inputUrl);

            var jobToAdd = Task.Factory.StartNew(() => Dispatcher());

            await jobToAdd;

            //foreach (string url in siteList)
            //{
            //    HttpResponseMessage httpResponse = await client.GetAsync(url);
            //    httpResponse.EnsureSuccessStatusCode();
            //    string newResponse = await httpResponse.Content.ReadAsStringAsync();
            //    var newMatches = urlRegex.Matches(newResponse);
            //}
        }

        static async void Dispatcher()
        { 
            while (_count < 5000)
            {
                _queueLock.WaitOne();

                if (queue.Count > 0)
                {
                    string url = queue.Dequeue();
                    Console.WriteLine("Site: " + url);
                    var startTask = Task.Factory.StartNew(() => ReadUrl(url));
                    _count++;
                }
                _queueLock.ReleaseMutex();

                await Task.Delay(2000);
            }
        }

        static async void ReadUrl(string url)
        {
            try
            {
                Console.WriteLine("URL: " + url);

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                var matches = urlRegex.Matches(responseBody);

                foreach (var match in matches)
                {
                    if (siteList.Add(match.ToString()))
                    {
                        queue.Enqueue(match.ToString());
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

