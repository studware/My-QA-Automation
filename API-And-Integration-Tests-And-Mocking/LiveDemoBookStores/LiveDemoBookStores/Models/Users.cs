namespace LiveDemoBookStores
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Users
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

       [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("wishlistId")]
        public long WishlistId { get; set; }

        [JsonProperty("householdId")]
        public long HouseholdId { get; set; }

        public static List<Users> FromJson(string json) => JsonConvert.
            DeserializeObject<List<Users>>(json, Converter.Settings);

    }
}

