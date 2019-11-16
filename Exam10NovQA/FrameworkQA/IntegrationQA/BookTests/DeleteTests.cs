//namespace IntegrationQA.BookTests
//{
//    using FluentAssertions;
//    using IntegrationQA.Models;
//    using NUnit.Framework;
//    using System.Threading.Tasks;

//    [TestFixture]
//    public class DeleteTests : BaseTest
//    {
//        [Test]
//        public async Task DeleteBookShouldSiccess()
//        {
//            //Arrange
//            string bookId = "9de699a7-4924-448c-910c-97bd27f6525b";

//            //Act
//            var response = await _client.DeleteAsync($"books/{bookId}");
//            response.EnsureSuccessStatusCode();
//            var responseContent = await response.Content.ReadAsStringAsync();

//            var actualBook = Book.FromJson(responseContent);

//            // Assert
//            Assert.NotNull(actualBook);
//            Assert.That(actualBook.Id == bookId);
//        }

//        [Test]
//        public async Task DeleteBook_WithInValidData_ShouldReturnServerError()
//        {
//            //Arrange
//            var expectedBook = new Book { Id = "", };

//            //Act
//            var response = await _client.DeleteAsync($"api/authors/books/{expectedBook.Id}");

//            //Assert
//            response.StatusCode.Should().Be(500);
//        }
//    }
//}

////var expectedBook = new Book
////      {
////          Title = "Da Book",
////          Description = "Best Book Ever"
////      };

////      actualBook.Title.Should().Be(expectedBook.Title);
////      actualBook.Description.Should().Be(expectedBook.Description);
