namespace LiveDemoBookStores
{
    using NUnit.Framework;
    using System;
    using System.Net.Http;

    public class BaseTest
    {
        //Arrange
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3000")
            };
            Client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }
    }
}
