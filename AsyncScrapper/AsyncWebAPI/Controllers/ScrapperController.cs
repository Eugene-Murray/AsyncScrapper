using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncWebAPI.Controllers
{
    public class ScrapperController : ApiController
    {
        [HttpGet]
        public async Task<string> FootballGossip()
        {
            var httpClient = new HttpClient();

            Task<string> getStringTask = httpClient.GetStringAsync("http://www.bbc.co.uk/sport/0/football/gossip/");

            await SlowTask();

            var urlContents = await getStringTask;

            return urlContents;
        }
        
        private static async Task SlowTask()
        {
            var random = new Random(5000);
            await Task.Delay(random.Next(10, 10000));
        }

    }
}