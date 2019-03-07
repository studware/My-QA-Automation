﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using LiveDemoBookStores;
//
//    var user = User.FromJson(jsonString);

namespace LiveDemoBookStores
{
    using System;
    using Newtonsoft.Json;

    public partial class User
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

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("householdId")]
        public long HouseholdId { get; set; }

        public static User FromJson(string json) => JsonConvert.
            DeserializeObject<User>(json, LiveDemoBookStores.Converter.Settings);

        public static User SampleUser()
        {
            return new User
            {
                Id = 7,
                Email = "kiko@mailfellow.com",
                FirstName = "Kiko",
                LastName = "Portoriko",
                WishlistId = 9,
                HouseholdId = 7
            };
        }

        
        public static User User1()
        {
            return new User
            {
                Email = "albena@lalalala.com",
                FirstName = "Albena",
                LastName = "Loleva",
                HouseholdId = StaticVariables.householdId
            };
        }

        public static User User2()
        {
            return new User
            {
                Email = "Ivan@kokoroko.com",
                FirstName = "Ivan",
                LastName = "Kokorokov",
                HouseholdId = StaticVariables.householdId
            };
        }
    }
}

