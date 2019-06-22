using IntegrationContainers.API.Tests.Extensions;
using IntegrationContainers.API.Tests.Fixtures;
using IntegrationContainers.Data.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationContainers.API.Tests
{
    [Collection("Integration containers collection")]
    public class UsersControllerTests : ControllerTestsBase
    {
        public UsersControllerTests(IntegrationContainersAppFactory integrationContainersFixture)
            : base(integrationContainersFixture)
        {
        }

        [Fact]
        public async Task GetUsers_NoUsers_ShouldReturnOk()
        {
            var response = await Client.GetAsync("api/users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetUsers_UsersInDb_ShouldReturnAddedUsers()
        {
            var user = new User { FirstName = "Sam", LastName = "Jonson" };
            Context.Add(user);
            Context.SaveChanges();

            var users = await Client.GetAsync("api/users").DeserializeResponseAsync<User[]>();

            Assert.NotEmpty(users);
        }
    }
}