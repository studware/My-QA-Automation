namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    [TestFixture]
    public class X3DeleteTests
    {
        private HttpClient _client;
 //       private HttpResponseMessage response;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://libexam2.azurewebsites.net/")
            };
        }

        [Test]
        public async Task DeleteAuthor_WithValidData_ShouldReturnSuccess()
        {
            //Arrange
 //           _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await _client.DeleteAsync("/api/authors/b432e132-e1ec-44e2-9e14-7f624263e49e");
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();

            var author = Author.FromJson(content);

            // Assert
            Assert.NotNull(author);
            Assert.That(author.Id == "b432e132-e1ec-44e2-9e14-7f624263e49e");
            author.Name.Should().Be("Agatha Christy");
        }
    }
}
