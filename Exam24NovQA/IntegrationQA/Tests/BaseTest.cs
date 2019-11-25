using NUnit.Framework;
using System;
using System.Net.Http;

namespace IntegrationQA.Tests
{
    public class BaseTest
    {
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://libexam2.azurewebsites.net/")
            };
        }
    }
}
