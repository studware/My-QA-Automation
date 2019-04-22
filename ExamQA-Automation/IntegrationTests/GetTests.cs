namespace Tests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class GetTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var test = Guid.Empty.ToString();
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libraryexam21.azurewebsites.net/")
            };
        }

        [Test]
        public async Task GetAuthor_WithValidId_Should_ReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                Id = "412c3012-d891-4f5e-9613-ff7aa63e6bb3",
                Name = "Neil Gaiman",
                Age = 58,
                Genre = "Fantasy" 
            };

            //Act
            var response = await _client.GetAsync($"/api/authors/{expectedAuthor.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(content);

            //Assert
            actualAuthor.Should().BeEquivalentTo(expectedAuthor);
        }

        [Test]
        public async Task GetAuthor_WithInvalidId_Should_ReturnNotFound()
        {
            //Act
            var response = await _client.GetAsync($"/api/authors/{Guid.Empty}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);  // Be(404)
        }
    }
}