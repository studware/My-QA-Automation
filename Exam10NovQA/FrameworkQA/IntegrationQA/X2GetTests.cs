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
    public class X2GetTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("http://libexam2.azurewebsites.net/")
            };
        }

        [Test]
        public async Task GetAuthor_WithValid_Id_ShouldSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                Id = "11a3c092-70b8-4c1d-9fb8-3f563676c02a",
                Name = "Jonathan Franzen",
                Age = 60,
                Genre = "Drama"
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
    }
}