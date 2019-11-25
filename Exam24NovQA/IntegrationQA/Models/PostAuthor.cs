namespace IntegrationQA.Models
{
    using Newtonsoft.Json;

    public partial class PostAuthor
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }

    public partial class PostAuthor
    {
        public static PostAuthor FromJson(string json) => JsonConvert
            .DeserializeObject<PostAuthor>(json, Extensions.Converter.Settings);
    }
}
