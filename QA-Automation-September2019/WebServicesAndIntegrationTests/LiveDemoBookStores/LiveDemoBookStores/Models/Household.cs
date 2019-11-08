﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using LiveDemoBookStores;
//
//    var household = Household.FromJson(jsonString);

namespace LiveDemoBookStores
{
    using System;
    using Newtonsoft.Json;

    public partial class Household
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        public static Household FromJson(string json) => JsonConvert.
            DeserializeObject<Household>(json, LiveDemoBookStores.Converter.Settings);

        public static Household SampleHousehold()
        {
            return new Household
            {
                Id = 1,
                Name = "Sofia"
            };
        }

        public static Household PostHousehold()
        {
            return new Household
            {
                Name = "Paris"
            };
        }
    }
}
