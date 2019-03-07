namespace LiveDemoBookStores
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    [TestFixture]
    public class UsersTests: BaseTest
    {
        [Test]
        public async Task GetUser2ShouldReturnOk()
        {
            //Act
            var response = await Client.GetAsync("/users/7");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\dataSamples\user7.json");
            var expected = File.ReadAllText(path);

            //Assert
            var responseUser = User.FromJson(content);

            responseUser.Should().BeEquivalentTo(
                    User.SampleUser(),
                    opt => opt.Excluding(user => user.CreatedAt).
                                Excluding(user => user.UpdatedAt).
                                Excluding(user => user.HouseholdId));

            //            content.Should().Be(expected);

            //            responseUser.Email.Should().Be(User.SampleUser().Email);
        }
    }
}
