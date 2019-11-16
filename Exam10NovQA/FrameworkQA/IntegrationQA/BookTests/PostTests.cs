//namespace IntegrationQA.BookTests
//{
//    using FluentAssertions;
//    using IntegrationQA.Extensions;
//    using IntegrationQA.Models;
//    using NUnit.Framework;
//    using System;
//    using System.Net.Http;
//    using System.Text;
//    using System.Threading.Tasks;

//    [TestFixture]
//    public class PostTests : BaseTest
//    { 
//        [Test]
//        public async Task PostBook_WithValidData_ShouldReturnSuccess()
//        {
//            //Arrange
//            Guid id = authorToPostId;

//            var expectedBook = new Book
//            {
//                Title = "Da Book",
//                Description = "Best Book Ever"
//            };
//            var jsonbook = expectedBook.ToJson();
//            StringContent requestContent = new StringContent(jsonbook, Encoding.UTF8, "application/json");

//            //Act
//            var response = await _client.PostAsync($"api/authors/{id.ToString()}/books", requestContent);
//            response.EnsureSuccessStatusCode();
//            var responseContent = await response.Content.ReadAsStringAsync();

//            var actualBook = Book.FromJson(responseContent);

//            //Assert
//            actualBook.Title.Should().Be(expectedBook.Title);
//            actualBook.Description.Should().Be(expectedBook.Description);
//        }

//        [Test]
//        public async Task PostBook_WithInValidData_ShouldReturnServerError()
//        {
//            //Arrange
//            Guid id = authorToPostId;

//            var expectedBook = new Book
//            {
//                Title = "",
//                Description = "Best Book Ever"
//            };
//            var jsonbook = expectedBook.ToJson();
//            StringContent requestContent = new StringContent(jsonbook);

//            //Act
//            var response = await _client.PostAsync($"api/authors/{id.ToString()}/books", requestContent);

//            //Assert
//            response.StatusCode.Should().Be(500);
//        }
//    }
//}
