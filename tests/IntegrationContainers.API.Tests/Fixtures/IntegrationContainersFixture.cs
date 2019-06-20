using IntegrationContainers.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationContainers.API.Tests.Fixtures
{
    public class IntegrationContainersFixture : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public MssqlContainerFixture ContainerFixture { get; }
        public TestContextConfiguration TestContextConfiguration { get; private set; }

        public IntegrationContainersFixture()
        {
            ContainerFixture = new MssqlContainerFixture();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), TestContextConfiguration));
            });
        }

        public Task DisposeAsync()
        {
            return ContainerFixture.DisposeAsync();
        }

        public async Task InitializeAsync()
        {
            await  ContainerFixture.InitializeAsync();
            TestContextConfiguration = new TestContextConfiguration(ContainerFixture.Container.GetConnectionString());
        }
    }
}