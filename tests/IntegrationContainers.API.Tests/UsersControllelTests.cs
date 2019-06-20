using IntegrationContainers.API.Tests.Fixtures;
using System;
using Xunit;

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
        public void Test()
        {

        }
    }
}
