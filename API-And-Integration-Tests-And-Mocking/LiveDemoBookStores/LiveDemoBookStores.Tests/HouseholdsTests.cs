namespace LiveDemoBookStores
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestFixture]
    public class HouseholdsTests: BaseTest
    {
        [Test]
        public async Task GetAllHouseholdsShouldReturnOk()
        {
            //Act
            var response = await Client.GetAsync("/households");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\dataSamples\households.json");
 //           var expected = File.ReadAllText(path);

            //Assert

            var households = Households.FromJson(content);

            var tested = households[0];

            tested.Should().BeEquivalentTo(
                        Household.SampleHousehold(),
                        opt=>opt.Excluding(h=>h.UpdatedAt).
                        Excluding(h=>h.CreatedAt));

            //           content.Should().Be(expected);

            //           tested.Id.Should().Be(Household.SampleBook().Id);
        }
    }
}

