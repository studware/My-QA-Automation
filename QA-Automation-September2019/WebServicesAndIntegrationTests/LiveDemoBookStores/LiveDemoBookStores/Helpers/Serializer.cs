namespace LiveDemoBookStores
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public static class Serializer
        {
            public static string ToJson(this Household self) => JsonConvert.SerializeObject(self, Converter.Settings);
            public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, Converter.Settings);
            public static string ToJson(this User self) => JsonConvert.SerializeObject(self, Converter.Settings);
            public static string ToJson(this List<Books> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
