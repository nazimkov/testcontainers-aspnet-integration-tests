using IntegrationContainers.API.Tests.Fixtures;
using System;
using System.Net;
using Xunit;
using System.Threading.Tasks;

namespace IntegrationContainers.API.Tests
{
    public class UsersControllersTests : IClassFixture<IntegrationContainersFixture>
    {
        private readonly IntegrationContainersFixture _integrationContainersFixture;

        public UsersControllersTests(IntegrationContainersFixture integrationContainersFixture)
        {
            _integrationContainersFixture = integrationContainersFixture;
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOk()
        {
            var client = _integrationContainersFixture.Server.CreateClient();
            var response = await client.GetAsync("api/users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
