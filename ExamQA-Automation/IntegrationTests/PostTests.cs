namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
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
                BaseAddress = new Uri("http://localhost:6058")
            };
        }

        [Test]
        public async Task PostAuthor_WithValidData_Should_ReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Angela",
                LastName = "Teneva",
                DateOfBirth = "1950-10-10T00: 03:20",
                Genre = "Drama"     // Comedy, Drama, Fantasy, Horror, Thriller
            };

            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseContent);

            //Assert
            actualAuthor.Name.Should().Be(expectedAuthor.FirstName + " " + expectedAuthor.LastName);
            actualAuthor.Genre.Should().Be("Drama");
            actualAuthor.Age.Should().Be(65);
        }

        [Test]
        public async Task PostAuthor_WithInvalidDate_Should_ReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Kuku",
                LastName = "Batman",
                DateOfBirth = "data",
                Genre = "Drama"
            };

            var requestContent = new StringContent(expectedAuthor.ToJson());

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
                FirstName = "Kuku",
                DateOfBirth = "data",
                Genre = "Drama"
            };

            var requestContent = new StringContent(expectedAuthor.ToJson());

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
                FirstName = "Kuku",
                LastName = "Batman",
                DateOfBirth = "data",
            };

            var requestContent = new StringContent(expectedAuthor.ToJson());

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