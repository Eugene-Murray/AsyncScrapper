using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAsync1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let the web api start up...");
            Thread.Sleep(5000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("# CallScrapperService().Result: " + CallScrapperService().Result.Length);
            }

            Console.ReadKey();
        }

        private static async Task<string> CallScrapperService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri("http://localhost:55361/");

            // Add an Accept header for JSON format. 
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/text"));

            Console.WriteLine("call url");
            Task<string> getStringTask = httpClient.GetStringAsync("api/Scrapper/FootballGossip");

            // Second Async Call...
            Console.WriteLine("@ AccessWebAsync().Result: " + AccessWebAsync().Result.Length);



            Console.WriteLine("await");
            var urlContents = await getStringTask;

            Console.WriteLine("return");
            return urlContents;
        }



        private static async Task<string> AccessWebAsync()
        {
            var httpClient = new HttpClient();

            Console.WriteLine("call url");
            Task<string> getStringTask = httpClient.GetStringAsync("http://www.bbc.co.uk/sport/0/football/gossip/");

            Console.WriteLine("await");
            var urlContents = await getStringTask;

            Console.WriteLine("return");
            return urlContents;
        }
    }
}
