namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class PostTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libraryexam21.azurewebsites.net/")
            };
        }

        [Test]
        public async Task PostAuthor_WithValidData_Should_ReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Agatha",
                LastName = "Cristie",
                DateOfBirth = "1949-10-10T00: 03:20",
                Genre = "Horror"
            };

            var requestContent = new StringContent(expectedAuthor.ToJson(), Encoding.UTF8, "application.json");

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseContent);

            //Assert
            actualAuthor.Name.Should().Be(expectedAuthor.FirstName + " " + expectedAuthor.LastName);
            actualAuthor.Genre.Should().Be("Horror");
            actualAuthor.Age.Should().Be(70);
        }

        [Test]
        public async Task PostAuthor_WithInvalidDate_Should_ReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Pavel",
                LastName = "Batman",
                DateOfBirth = "some data",
                Genre = "Drama"
            };

            var requestContent = new StringContent(expectedAuthor.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithInvalidName_Should_ReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Pavel",
                DateOfBirth = "2000-04-12T00: 06:25",
                Genre = "Drama"
            };

            var requestContent = new StringContent(expectedAuthor.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithInvalidGenre_Should_ReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Pavel",
                LastName = "Batman",
                DateOfBirth = "2000-04-12T00: 06:25",
            };

            var requestContent = new StringContent(expectedAuthor.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithNoData_Should_ReturnInternalServerError()
        {
            //Act
            var response = await _client.PostAsync("/api/authors/", null);

            //Assert
            response.StatusCode.Should().Be(500);
        }
    }
}