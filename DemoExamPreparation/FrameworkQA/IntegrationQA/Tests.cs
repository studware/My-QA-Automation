namespace IntegrationQA
{
    using IntegrationQA.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class Tests
    {
        private HttpClient _client;
        private string _id;
        //       private HttpResponseMessage response;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var author = new PostAuthor
            {
                FirstName = "Code1",
                LastName = "Code2",
                Genre = "Genre"
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;
            var actualAuthor = ResponseAuthor.FromJson(responseAsString);
            _id = actualAuthor.Id.ToString();
        }

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libexam2.azurewebsites.net/")
            };
        }

        [Test]
        public async Task GetAuthor()
        {
            //Arrange
            var expectedAuthor = new ResponseAuthor
            {
                Name = "Test1 Test2",
                Genre = "Test3",
                Age = 2018
            };

            var response = await _client.GetAsync("/api/authors/76053df4-6687-4353-8937-b45556748abe");
//            var response = await _client.GetAsync($"/api/authors/{_id}");
            response.EnsureSuccessStatusCode();

            // Act
            var responseAsString = response.Content.ReadAsStringAsync().Result;
            var author = ResponseAuthor.FromJson(responseAsString);

            // Assert
            Assert.AreEqual(expectedAuthor.Name, author.Name);
            Assert.AreEqual(expectedAuthor.Genre, author.Genre);
            Assert.AreEqual(expectedAuthor.Age, author.Age);
        }

        [Test]
        public async Task GetAuthorNegative()
        {
            //Arrange&Act
            var response = await _client.GetAsync("/api/authors/3");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);  // 404
        }

        [Test]
        public async Task PostAuthor()
        {
            //Arrange
            var author = new PostAuthor
            {
                FirstName = "Code1",
                LastName = "Code2",
                Genre = "Genre"
            };

            var expectedAuthor = new ResponseAuthor
            {
                Name = "Code1 Code2",
                Genre = "Genre",
                Age = 2018
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;
            var actualAuthor = ResponseAuthor.FromJson(responseAsString);

            // Assert
            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
            Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age);
            Assert.IsNotNull(actualAuthor.Id);
        }

        [Test]
        public async Task PostAuthorWithoutFirstName()
        {
            //Arrange
            var content = new StringContent(String.Empty, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors", content);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);  // 400
        }
    }
}
