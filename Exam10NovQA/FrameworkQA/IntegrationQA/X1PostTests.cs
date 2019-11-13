namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    [TestFixture]
    public class X1PostTests
    {
        private HttpClient _client;
        private HttpResponseMessage response;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libexam2.azurewebsites.net/")
            };

            _client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //           _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        [Test]
        public async Task PostAuthor_WithValidData_ShouldReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Dimitar",
                LastName = "Talev",
                DateOfBirth = "1948-03-04T00:00:00",
                Genre = "Drama"
            };
            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            response = await _client.PostAsync("/api/authors/", requestContent); 
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseContent);

            //Assert
            actualAuthor.Name.Should().Be(expectedAuthor.FirstName + " " + expectedAuthor.LastName);
            actualAuthor.Genre.Should().Be("Drama");
            actualAuthor.Age.Should().Be(71);
        }
     }
}
