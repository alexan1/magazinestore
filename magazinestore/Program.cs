﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace magazinestore
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseapi = "http://magazinestore.azurewebsites.net/api/";
            var tokenapi = "token";
            var urltoken = baseapi + tokenapi;
            var subscribersapi = "subscribers/" + GetTokenAsync(urltoken).Result;
            var urlsubscriber =baseapi + subscribersapi;

            var result = GetSubscribers(urlsubscriber).Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }        
        public static async Task<string> GetTokenAsync(string url)
        {
            var client = new HttpClient();            
            var json = await client.GetStringAsync(url);
            var result = JObject.Parse(json)["token"].ToString();            
            return result;
        }

        public static async Task<string> GetSubscribers(string url)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var result = JObject.Parse(json)["data"].AsJEnumerable()[0]["magazineIds"].ToString();
            return result;
        }
    }
}
