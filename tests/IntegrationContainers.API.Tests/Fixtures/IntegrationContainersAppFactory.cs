using IntegrationContainers.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationContainers.API.Tests.Fixtures
{
    public class IntegrationContainersAppFactory : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public MssqlContainerFixture ContainerFixture { get; }
        public string ConnectionString { get; private set; }
        public TestContextConfiguration TestContextConfiguration { get; private set; }

        public IntegrationContainersAppFactory()
        {
            ContainerFixture = new MssqlContainerFixture();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), TestContextConfiguration));
            });

            base.ConfigureWebHost(builder);
        }

        public async Task DisposeAsync()
        {
            await ContainerFixture.DisposeAsync();
        }

        public async Task InitializeAsync()
        {
            await ContainerFixture.InitializeAsync();
            ConnectionString = ContainerFixture.Container.GetConnectionString();
            TestContextConfiguration = new TestContextConfiguration(ConnectionString);
        }
    }
}