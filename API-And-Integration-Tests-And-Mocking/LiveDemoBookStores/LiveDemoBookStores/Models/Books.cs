namespace LiveDemoBookStores
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Books
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        public static List<Books> FromJson(string json) => JsonConvert.
            DeserializeObject<List<Books>>(json, Converter.Settings);

    }
}

