namespace LiveDemoBookStores
{
    using NUnit.Framework;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class WishlistsTests : BaseTest
    {
        [Test]
        [Order(1)]
        public async Task PostHouseholdShouldCreate()
        {
            //Arrange
            var requestBody = new StringContent(Household.PostHousehold().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/households", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var household = Household.FromJson(content);
            StaticVariables.householdId = household.Id;

            // Assert
            Assert.That(household.Name == "Paris");
        }

        [Test]
        [Order(2)]
        public async Task PostUser1ShouldCreate()
        {
            //Arrange
            User expected = User.User1();
            var requestBody = new StringContent(User.User1().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/users", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseUser = User.FromJson(content);
            StaticVariables.wishlistIdUser1 = responseUser.WishlistId;

            // Assert
            Assert.That(responseUser.HouseholdId == expected.HouseholdId);
            Assert.That(responseUser.FirstName == expected.FirstName);
            Assert.That(responseUser.LastName == expected.LastName);
            Assert.That(responseUser.Email == expected.Email);
        }

        [Test]
        [Order(3)]
        public async Task PostUser2ShouldCreate()
        {
            //Arrange
            User expected = User.User2();
            var requestBody = new StringContent(User.User2().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/users", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseUser = User.FromJson(content);
            StaticVariables.wishlistIdUser2 = responseUser.WishlistId;

            // Assert
            Assert.That(responseUser.HouseholdId == expected.HouseholdId);
            Assert.That(responseUser.FirstName == expected.FirstName);
            Assert.That(responseUser.LastName == expected.LastName);
            Assert.That(responseUser.Email == expected.Email);
        }

        [Test]
        [Order(4)]
        public async Task PostBook1User1ShouldCreate()
        {
            //Arrange
            Book expected = Book.Book1User1();
            var requestBody = new StringContent(Book.Book1User1().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/books", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseBook = Book.FromJson(content);
            StaticVariables.book1IdUser1 = responseBook.Id;


            // Assert
            Assert.That(responseBook.Title == expected.Title);
            Assert.That(responseBook.Author == expected.Author);
            Assert.That(responseBook.PublicationDate == expected.PublicationDate);
            Assert.That(responseBook.Isbn == expected.Isbn);
        }

        [Test]
        [Order(5)]
        public async Task PostBook2User1ShouldCreate()
        {
            //Arrange
            Book expected = Book.Book2User1();
            var requestBody = new StringContent(Book.Book2User1().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/books", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseBook = Book.FromJson(content);

            // Assert
            Assert.That(responseBook.Title == expected.Title);
            Assert.That(responseBook.Author == expected.Author);
            Assert.That(responseBook.PublicationDate == expected.PublicationDate);
            Assert.That(responseBook.Isbn == expected.Isbn);
        }

        [Test]
        [Order(6)]
        public async Task PostBook1User2ShouldCreate()
        {
            //Arrange
            Book expected = Book.Book1User2();
            var requestBody = new StringContent(Book.Book1User2().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/books", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseBook = Book.FromJson(content);
            StaticVariables.book1IdUser2 = responseBook.Id;

            // Assert
            Assert.That(responseBook.Title == expected.Title);
            Assert.That(responseBook.Author == expected.Author);
            Assert.That(responseBook.PublicationDate == expected.PublicationDate);
            Assert.That(responseBook.Isbn == expected.Isbn);
        }

        [Test]
        [Order(7)]
        public async Task PostBook2User2ShouldCreate()
        {
            //Arrange
            Book expected = Book.Book2User2();
            var requestBody = new StringContent(Book.Book2User2().ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/books", requestBody);
            response.EnsureSuccessStatusCode();

            // Act
            var content = await response.Content.ReadAsStringAsync();
            var responseBook = Book.FromJson(content);

            // Assert
            Assert.That(responseBook.Title == expected.Title);
            Assert.That(responseBook.Author == expected.Author);
            Assert.That(responseBook.PublicationDate == expected.PublicationDate);
            Assert.That(responseBook.Isbn == expected.Isbn);
        }

        [Test]
        [Order(8)]
        public async Task PostBookToWishlistUser1ShouldCreate()
        {
            // Arange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await Client.PostAsync("/wishlists/" + StaticVariables.wishlistIdUser1 + "/books/" + StaticVariables.book1IdUser1, null);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        [Order(9)]
        public async Task PostBookToWishlistUser2ShouldCreate()
        {
            // Arange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await Client.PostAsync("/wishlists/" + StaticVariables.wishlistIdUser2 + "/books/" + StaticVariables.book1IdUser2, null);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        [Order(10)]
        public async Task PostBook2ToWishlistUser1ShouldCreate()
        {
            // Arange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await Client.PostAsync("/wishlists/" + StaticVariables.wishlistIdUser1 + "/books/" + StaticVariables.book2IdUser1, null);
//            var response = await Client.PostAsync("/wishlists/24/books/24", null);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        [Order(9)]
        public async Task PostBook2ToWishlistUser2ShouldCreate()
        {
            // Arange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            var response = await Client.PostAsync("/wishlists/" + StaticVariables.wishlistIdUser2 + "/books/" + StaticVariables.book2IdUser2, null);
//            var response = await Client.PostAsync("/wishlists/25/books/26", null);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        [Order(13)]
        public async Task HouseholdWishlistsBooksCheckUnique()
        {
            //Arrange
            var response = await Client.GetAsync("/households/" + StaticVariables.householdId + "/wishlistBooks");
            response.EnsureSuccessStatusCode();


            //Act
            var content = await response.Content.ReadAsStringAsync();
            var booksList = Books.FromJson(content);
            long expectedCount = booksList.Count;
            var uniqueBooksList = booksList.Select(x => x.Isbn).Distinct();
            long uniqueBooksCount = uniqueBooksList.LongCount();

            //Assert
            Assert.AreEqual(uniqueBooksCount, expectedCount);
        }

        [Test]
        [Order(14)]
        public async Task AllBooksCheckUnique()
        {
            //Arrange
            var response = await Client.GetAsync("/books");
            response.EnsureSuccessStatusCode();


            //Act
            var content = await response.Content.ReadAsStringAsync();
            var booksList = Books.FromJson(content);
            long expectedCount = booksList.Count;
            var uniqueBooksList = booksList.Select(x => x.Title).Distinct();
            long uniqueBooksCount = uniqueBooksList.Count();

            //Assert
            Assert.AreNotEqual(uniqueBooksCount, expectedCount);
        }
    }
}
