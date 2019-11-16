namespace IntegrationQA.Extensions
{
    using IntegrationQA.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public static class Serializer
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Books> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}