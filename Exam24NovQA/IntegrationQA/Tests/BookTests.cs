namespace IntegrationQA.Tests
{
    using IntegrationQA.Models;
    using NUnit.Framework;
    using IntegrationQA.Extensions;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;

    [TestFixture]
    public class BookTests : BaseTest
    {
        public string bookId;
        public string authorId;

        [Test]
        [Order(1)]
        public async Task CreateAuthorTest()
        {
            var author = new PostAuthor()
            {
                FirstName = "Boris",
                LastName = "Aprilov",
                Genre = "Fairy Tales"
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/authors", content);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = GetAuthor.FromJson(responseAsString);
            Assert.AreEqual(author.FirstName + " " + author.LastName, actualAuthor.Name);
            authorId = actualAuthor.Id;
        }

        [Test]
        [Order(2)]
        public async Task GetAuthorTest()
        {
            var expectedAuthor = new GetAuthor
            {
                Id = authorId,
                Name = "Boris Aprilov",
                Genre = "Fairy Tales"
            };
            var response = await Client.GetAsync($"api/authors/{authorId}");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = GetAuthor.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Id, actualAuthor.Id);
        }

        [Test]
        [Order(3)]
        public async Task PostBookTest()
        {
            var book = new PostBook()
            {
                Title = "Lisko",
                Description = "Lisko's adventures",
                AuthorId = $"{authorId}"
            };

            var content = new StringContent(book.ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"api/authors/{authorId}/books", content);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualBook = GetBook.FromJson(responseAsString);
            Assert.AreEqual(book.Title, actualBook.Title);
            bookId = actualBook.Id;
        }

        [Test]
        [Order(4)]
        public async Task GetBookTest()
        {
            var expectedBook = new GetBook
            {
                Id = bookId,
                Title = "Lisko",
                Description = "Lisko's adventures"
            };
            var response = await Client.GetAsync($"api/authors/{authorId}/books/{bookId}");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualBook = GetBook.FromJson(responseAsString);

            Assert.AreEqual(expectedBook.Title, actualBook.Title);
            Assert.AreEqual(expectedBook.Id, actualBook.Id);
        }

        [Test]
        [Order(5)]
        public async Task DeleteBook()
        {
            var response = await Client.DeleteAsync($"api/authors/{authorId}/books/{bookId}");
            response.EnsureSuccessStatusCode();
            var getDeletedAuthorResponse = await Client.GetAsync($"api/authors/{authorId}/books/{bookId}");
            Assert.AreEqual(HttpStatusCode.NotFound, getDeletedAuthorResponse.StatusCode);
        }
    }
}

// Author Id: 1ec8efab-3177-4a45-a854-2efa6266f6dd  Vladimir Zarev

// Author Id:  f6b1f433-ca6e-4402-89e1-d11a62ab77c5 // Boris Aprilov