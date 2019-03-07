namespace LiveDemoBookStores
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Households
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public static List<Households> FromJson(string json) => JsonConvert.
            DeserializeObject<List<Households>>(json, Converter.Settings);

    }
}

