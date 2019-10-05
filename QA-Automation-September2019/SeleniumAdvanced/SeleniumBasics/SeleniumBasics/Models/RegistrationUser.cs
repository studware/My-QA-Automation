namespace SeleniumBasics.Models
{
    using Newtonsoft.Json;
    using SeleniumBasics.Helpers;
    using System;

    public partial class RegistrationUser
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTimeOffset? DateOfBirth { get; set; }
    }
    public partial class RegistrationUser
    {
        public static RegistrationUser FromJson(string json) => JsonConvert.DeserializeObject<RegistrationUser>(json, Converter.Settings);
    }
}

