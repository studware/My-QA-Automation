namespace IntegrationQA
{
    using FluentAssertions;
    using IntegrationQA.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class X3DeleteTests: BaseTest
    {
        [Test]
        public async Task DeleteAuthor_WithValid_Id_ShouldReturnSuccess()
        {
            //Arrange
            HttpResponseMessage response = await _client.DeleteAsync($"/api/authors/{authorId}");
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var author = Author.FromJson(content);

            // Assert
            Assert.NotNull(author);
            Assert.AreEqual(authorId, author.Id);
        }

        [Test]
        public async Task DeleteAuthor_With_InValid_Id_Should_Not_Return_OK()
        {
            //Arrange&Act
            HttpResponseMessage response = await _client.DeleteAsync($"/api/authors/{String.Empty}");

            // Assert
            int responseStatus = (int)response.StatusCode;
            response.StatusCode.Should().NotBeEquivalentTo((int)HttpStatusCode.OK);
            Assert.That(responseStatus >= 400);
        }
    }
}

//           _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");

//            authorId = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f").ToString();
//            HttpResponseMessage response = await _client.DeleteAsync($"/api/authors/f74d6899-9ed2-4137-9876-66b070553f8f");