using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace magazinestore
{
    public class Subscriber
    {      

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("magazineIds")]
        public long[] MagazineIds { get; set; }
    }
}
