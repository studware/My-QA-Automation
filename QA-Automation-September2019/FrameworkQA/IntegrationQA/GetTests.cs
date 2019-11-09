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
                BaseAddress = new System.Uri("http://localhost:6058/")
            };
        }

        [Test]
        public async Task GetAuthor_WithValid_Id_ShouldSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                Id = "a1da1d8e-1988-4634-b538-a01709477b77",
                Name = "Jens Lapidus",
                Age = 44,
                Genre = "Thriller"
            };

            //Act
            var response = await _client.GetAsync($"api/authors/{expectedAuthor.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(content);

            //Assert
            actualAuthor.Should().BeEquivalentTo(expectedAuthor);

            //Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            //Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
            //Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age);
        }

        [Test]
        public async Task GetAuthor_With_Invalid_Id_ShouldReturnNotFound()
        {
            //Arrange&Act
            var response = await _client.GetAsync($"api/authors/{Guid.Empty}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

      //      Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}