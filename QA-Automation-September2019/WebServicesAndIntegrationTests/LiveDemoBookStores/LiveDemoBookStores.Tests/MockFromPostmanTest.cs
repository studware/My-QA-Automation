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

    // A mock test using mocking by Postman
    [TestFixture]
    public class MockFromPostmanTest: BaseTest
    { 
        [Test]
        public async Task GetHouseholdOwnedBooksShould()
        {
            //Arrange
            Client.BaseAddress = new Uri("https://f584b014-c123-4048-aa8d-bfcf83c8163a.mock.pstmn.io"); //from my Postman mock MockHouse

            //Act
            var response = await Client.GetAsync("/households/2/OwnedBooks");
            response.StatusCode.
                Should().
                Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
        }
    }
}

