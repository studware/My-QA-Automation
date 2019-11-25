namespace IntegrationQA.Models
{
    using Newtonsoft.Json;

    public partial class GetAuthor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }

    public partial class GetAuthor
    {
        public static GetAuthor FromJson(string json) => JsonConvert
            .DeserializeObject<GetAuthor>(json, Extensions.Converter.Settings);
    }
}
