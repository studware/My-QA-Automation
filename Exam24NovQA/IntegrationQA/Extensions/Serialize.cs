namespace IntegrationQA.Extensions
{
    using IntegrationQA.Models;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static string ToJson(this PostAuthor self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public static string ToJson(this PostBook self) => JsonConvert.SerializeObject(self, Converter.Settings);
     }
}