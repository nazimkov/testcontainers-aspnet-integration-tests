using IntegrationContainers.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationContainers.API.Tests.Fixtures
{
    public class IntegrationContainersAppFactory : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public MssqlContainerFixture ContainerFixture { get; }
        public string ConnectionString { get; private set; }
        public TestContextConfiguration TestContextConfiguration { get; private set; }

        public HttpClient Client { get; private set; }

        public IntegrationContainersAppFactory()
        {
            ContainerFixture = new MssqlContainerFixture();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
                services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), TestContextConfiguration));
            });
        }


        public Task DisposeAsync() => ContainerFixture.DisposeAsync();

        public async Task InitializeAsync()
        {
            await ContainerFixture.InitializeAsync();
            ConnectionString = ContainerFixture.Container.GetConnectionString();
            TestContextConfiguration = new TestContextConfiguration(ConnectionString);

            Client =  CreateClient();

            using (var scope = Server.Host.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices
                    .GetRequiredService<UsersDataContext>();

                context.Database.Migrate();
            }
        }
    }
}