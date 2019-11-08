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
        [Order(13)]
        public async Task GetAllHouseholdsShouldReturnOk()
        {
            //Arrange&Act
            var response = await Client.GetAsync("/households");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);
        }

        [Test]
        [Order(14)]
        public async Task GetHouseholdsShouldHaveAtLeastOneHouseHold()
        {
            //Arrange&Act
            var response = await Client.GetAsync("/households");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var householdsCount = Households.FromJson(content).Count;

            //Assert
            householdsCount.Should().BeGreaterThan(0);
        }
    }
}

