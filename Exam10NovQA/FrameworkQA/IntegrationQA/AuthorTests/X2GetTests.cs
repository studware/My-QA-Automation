namespace IntegrationQA
{
    using FluentAssertions;
    using IntegrationQA.Models;
    using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
    public class X2GetTests: BaseTest
    {
        [Test]
        public async Task GetAllAuthors()
        {
            //Act
            var response = await _client.GetAsync($"api/authors");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var authors = Authors.FromJson(content);
            authorId = authors[1].Id;
            authorToGetName = authors[1].Name;
            authorToGetAge = authors[1].Age;
            authorToGetGenre = authors[1].Genre;
            count = authors.Count;
            //Assert
            Assert.That(count > 0);
        }

        [Test]
        public async Task GetAuthor_WithValid_Id_ShouldSucceed()
        {
            //Arrange
            var expectedAuthor = new Author
            {
                Id = authorId,
                Name = authorToGetName,
                Age = authorToGetAge,
                Genre = authorToGetGenre
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