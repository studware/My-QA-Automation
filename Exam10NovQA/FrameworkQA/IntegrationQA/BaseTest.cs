using NUnit.Framework;
using System;
using System.Net.Http;

namespace IntegrationQA
{
    public class BaseTest
    {
        public HttpClient _client;
        public HttpResponseMessage response;
        public string authorId;   
        public string authorToGetName;
        public long authorToGetAge;
        public string authorToGetGenre;
        public int count;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libexam2.azurewebsites.net/")
            };

//            authorId = Guid.NewGuid().ToString().Substring(0, 10);
        }
    }
}

/*
_client.DefaultRequestHeaders.Add("Content-Type", "application/json");
response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
*/
