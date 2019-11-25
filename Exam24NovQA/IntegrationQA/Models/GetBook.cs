namespace IntegrationQA.Models
{
    using Newtonsoft.Json;

    public partial class GetBook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("authorId")]
        public string AuthorId { get; set; }
    }

    public partial class GetBook
    {
        public static GetBook FromJson(string json) => JsonConvert
            .DeserializeObject<GetBook>(json, Extensions.Converter.Settings);
    }
}
