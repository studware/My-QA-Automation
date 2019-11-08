﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using LiveDemoBookStores;
//
//    var book = Book.FromJson(jsonString);

namespace LiveDemoBookStores
{
    using System;
    using Newtonsoft.Json;

    public partial class Book
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publicationDate")]
 //       public DateTimeOffset PublicationDate { get; set; }
        public string PublicationDate { get; set; }

        [JsonProperty("isbn")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Isbn { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        public static Book FromJson(string json) => JsonConvert.
            DeserializeObject<Book>(json, Converter.Settings);

        public static Book SampleBook()
        {
            return new Book
            {
                Id = 1,
                Title = "Don't Waste Your Life",
                Author = "John Piper",
                // PublicationDate = new DateTimeOffset(new DateTime(2003, 05, 15).ToUniversalTime()),
                PublicationDate = "2003-05-15",
                Isbn = 1593281056
            };
        }

        public static Book PostBook()
        {
            return new Book
            {
                Id=19,
                Title = "BookToDelete",
                Author = "Cool Author",
                // PublicationDate = new DateTimeOffset(new DateTime(2003, 05, 15).ToUniversalTime()),
                PublicationDate = "1949-10-25",
                Isbn = 8493027489
            };
        }

        public static Book Book1User1()
        {
            return new Book
            {
                Title = "Book1User1",
                Author = "Cool Author1",
                PublicationDate = "1909-10-25",
                Isbn = 0278493489
            };
        }

        public static Book Book2User1()
        {
            return new Book
            {
                Title = "Book2User1",
                Author = "Cool Author2",
                PublicationDate = "1999-05-16",
                Isbn = 8427489930
            };
        }

        public static Book Book1User2()
        {
            return new Book
            {
                Title = "Book1User2",
                Author = "Cool Author3",
                PublicationDate = "2009-09-28",
                Isbn = 3028497489
            };
        }

        public static Book Book2User2()
        {
            return new Book
            {
                Title = "Book2User2",
                Author = "Cool Author4",
                PublicationDate = "2019-03-07",
                Isbn = 8493021749
            };
        }
    }
}

