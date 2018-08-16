using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace magazinestore
{
    public class Wrapper<T>
    {
        //[JsonProperty("data")]
        public T[] Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        public static Wrapper<T> FromJson(string json) => JsonConvert.DeserializeObject<Wrapper<T>>(json, Settings);

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
