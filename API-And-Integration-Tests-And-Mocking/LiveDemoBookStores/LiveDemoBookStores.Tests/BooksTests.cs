namespace LiveDemoBookStores
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    [TestFixture]
    public class BooksTests: BaseTest
    {
        [Test]
        public async Task GetBook1ShouldReturnOk()
        {
            //Act
            var response = await Client.GetAsync("/books/1");  // response.EnsureSuccessStatusCode();
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\dataSamples\book1.json");
            var expected = File.ReadAllText(path);

            //Assert
            var responseBook = Book.FromJson(content);

            responseBook.Should().BeEquivalentTo(
                    Book.SampleBook(),
                    opt => opt.Excluding(book => book.CreatedAt).
                                Excluding(book => book.UpdatedAt));

            //            content.Should().Be(expected);

            //            responseBook.Isbn.Should().Be(Book.SampleBook().Isbn);
        }

        //[Test]
        //public async Task DeleteBookShouldCreate()
        //{
        //    //Arrange
        //    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
        //    var response = await Client.DeleteAsync("/books/19");
        //    response.EnsureSuccessStatusCode();
        //    /* Unhandled rejection SequelizeForeignKeyConstraintError: update or delete on table "books" violates 
        //     * foreign key constraint "wishlistBooks_bookId_fkey" on table "wishlistBooks" */

        //    // Act
        //    var content = await response.Content.ReadAsStringAsync();
        //    var book = Book.FromJson(content);

        //    // Assert
        //    Assert.NotNull(book);
        //    Assert.That(book.Id == 19);
        //}
    }
}
