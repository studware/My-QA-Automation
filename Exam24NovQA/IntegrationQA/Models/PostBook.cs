namespace IntegrationQA.Models
{
    using Newtonsoft.Json;

    public partial class PostBook
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }
    }

    public partial class PostBook
    {
        public static PostBook FromJson(string json) => JsonConvert
            .DeserializeObject<PostBook>(json, Extensions.Converter.Settings);
    }
}
