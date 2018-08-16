using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace magazinestore
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseapi = "http://magazinestore.azurewebsites.net/api/";
            var tokenapi = "token";
            var urltoken = baseapi + tokenapi;
            var token = GetTokenAsync(urltoken).Result;
            var subscribersapi = "subscribers/" + token;
            var urlsubscriber =baseapi + subscribersapi;
            var categoriesapi = "categories/" + token;
            var urlcategories = baseapi + categoriesapi;


            var numcategories = GetCategories(urlcategories).Result.Count();
            Console.WriteLine(numcategories);
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

        public static async Task<List<Subscriber>> GetSubscribers(string url)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);

            var welcome = Wrapper<Subscriber>.FromJson(json);

            //var people = JsonConvert.DeserializeObject<Wrapper<Subscriber>>(json);
            var people = welcome.Data.ToList();
            
            return people;
        }

        public static async Task<List<string>> GetCategories(string url)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);

            var welcome = Wrapper<string>.FromJson(json);
            var categories = welcome.Data.ToList();

            return categories;
        }
    }
}
