using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAsync1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AccessWebAsync().Result);

            Console.ReadKey();
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
