namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
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
        public async Task PostAuthor_WithValidData_ShouldReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Ventsi",
                LastName = "Batman",
                DateOfBirth = "1944-03-04T00: 00:00",
                Genre = "Comedy"
            };
            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseContent);

            //Assert
            actualAuthor.Name.Should().Be(expectedAuthor.FirstName + " " + expectedAuthor.LastName);
            actualAuthor.Genre.Should().Be("Comedy");
            actualAuthor.Age.Should().Be(65);
        }

        [Test]
        public async Task PostAuthor_WithInvalidDate_ShouldReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Ventsi",
                LastName = "Batman",
                DateOfBirth = "date",
                Genre = "Comedy"
            };
            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithInvalidName_ShouldReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Ventsi",
                DateOfBirth = "date",
                Genre = "Comedy"
            };
            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithInvalidGenre_ShouldReturnBadRequest()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Ventsi",
                LastName = "Batman",
                DateOfBirth = "date"
            };
            var requestContent = new StringContent(expectedAuthor.ToJson());

            //Act
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task PostAuthor_WithNoData_ShouldReturnInternalServerError()
        {
            var response = await _client.PostAsync("/api/authors/", null);
            response.StatusCode.Should().Be(500);
        }
    }
}
