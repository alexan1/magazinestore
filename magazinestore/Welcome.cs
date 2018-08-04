using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace magazinestore
{
    public class Welcome
    {
        [JsonProperty("data")]
        public Subscriber[] Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }
}
