namespace IntegrationQA
{
    using FluentAssertions;
    using IntegrationQA.Extensions;
    using IntegrationQA.Models;
    using NUnit.Framework;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class X1PostTests: BaseTest
    {
        [Test]
        public async Task PostAuthor_WithValidData_ShouldReturnSuccess()
        {
            //Arrange
//            var expectedAuthor = Author.PostAuthor();
            var expectedAuthor = Author.PostSampleAuthor();

            //Act
            var authorInJson = expectedAuthor.ToJson();
            var requestContent = new StringContent(authorInJson, Encoding.UTF8, "application/json");
 //           _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await _client.PostAsync($"/api/authors", requestContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var responseContent = await response.Content.ReadAsStringAsync();
            var actualAuthors = Authors.FromJson(responseContent);

            //Assert
            actualAuthors[1].Name.Should().Be(expectedAuthor.FirstName + " " + expectedAuthor.LastName);
            actualAuthors[1].Genre.Should().Be("Biographical");
            actualAuthors[1].Age.Should().Be(2018);
//            actualAuthors[1].Age.Should().Be(72);
        }
     }
}
