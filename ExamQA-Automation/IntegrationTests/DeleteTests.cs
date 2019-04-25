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
    public class DeleteTests
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
        public async Task DeleteValidAuthor_ShouldReturnSuccess()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                FirstName = "Boris",
                LastName = "Aprilov",
                DateOfBirth = "1909-12-04T00: 03:20",
                Genre = "Comedy"
            };

            //Act
            //create new author to delete it later
            var requestContent = new StringContent(expectedAuthor.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/authors/", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var newAuthor = Author.FromJson(responseContent);
            //delete the new book
            var deleteResponse = await _client.DeleteAsync("/api/authors/{newAuthor.authorId}/");

            //Assert
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task DeleteUnexistingAuthor_ShouldReturnBadRequest()
        {
            //Arrange
            var authorWithInvalidId = new Author
            {
                Id = "eb6b4118-d52e-4c96-9b54-2e51ae91a4c3"
            };

            var requestContent = new StringContent(authorWithInvalidId.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var deleteResponse = await _client.DeleteAsync($"/api/authors/{authorWithInvalidId}");

            //Assert
            deleteResponse.StatusCode.Should().Be(403);
        }

        [Test]
        public async Task DeleteAuthorWithInvalidName_ShouldReturnInternalServerError()
        {
            //Arrange
            var authorWithInvalidName = new Author
            {
                FirstName = "",
                LastName = "",
                DateOfBirth = "2005-01-04T00: 03:20",
                Genre = "Drama"
            };

            var requestContent = new StringContent(authorWithInvalidName.ToJson(), Encoding.UTF8, "application/json");

            //Act
            var deleteResponse = await _client.DeleteAsync($"/api/authors/{authorWithInvalidName}");

            //Assert
            deleteResponse.StatusCode.Should().Be(404);
        }
    }
}