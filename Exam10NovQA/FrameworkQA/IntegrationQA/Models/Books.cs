namespace IntegrationQA.Models
{
    using System.Collections.Generic;
    using IntegrationQA.Extensions;
    using Newtonsoft.Json;

    public partial class Books
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        public static List<Book> FromJson(string json) => JsonConvert.
            DeserializeObject<List<Book>>(json, Converter.Settings);

    }
}