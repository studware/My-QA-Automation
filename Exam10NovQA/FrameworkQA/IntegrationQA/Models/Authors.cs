namespace IntegrationQA.Models
{
    using System.Collections.Generic;
    using IntegrationQA.Extensions;
    using Newtonsoft.Json;

    public partial class Authors
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        public static List<Authors> FromJson(string json) => JsonConvert.
            DeserializeObject<List<Authors>>(json, Converter.Settings);

    }
}
