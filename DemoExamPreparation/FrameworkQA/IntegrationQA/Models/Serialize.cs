using Newtonsoft.Json;

namespace IntegrationQA.Models
{
    public static class Serialize
    {
        public static string ToJson(this ResponseAuthor self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public static string ToJson(this PostAuthor self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}