namespace LiveDemoBookStores
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    [TestFixture]
    public class UsersTests : BaseTest
    {
        [Test]
        [Order(15)]
        public async Task GetUser2ShouldReturnOk()
        {
            //Act
            var response = await Client.GetAsync("/users/2");

            //Assert
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);
        }

        [Test]
        [Order(16)]
        public async Task GetUser2ShouldHaveCorrectContent()
        {
            //Act
            var response = await Client.GetAsync("/users/2");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            //Assert
            var responseUser = User.FromJson(content);
            string responseUserFullName = responseUser.FirstName + " " + responseUser.LastName;

            responseUserFullName.Should().BeEquivalentTo(
                    User.User2().FirstName + " " + User.User2().LastName);

            //            responseUser.Email.Should().Be(User.User2().Email);
        }
    }
}
