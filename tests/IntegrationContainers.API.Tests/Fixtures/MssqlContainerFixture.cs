using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestContainers.Container.Abstractions.Hosting;
using TestContainers.Container.Database.Hosting;
using TestContainers.Container.Database.MsSql;
using Xunit;

namespace IntegrationContainers.API.Tests.Fixtures
{
    public class MssqlContainerFixture : IAsyncLifetime
    {
        public MsSqlContainer Container { get; }

        public string Username { get; } = "sa";

        public string Password { get; } = "Pass@word!";

        public MssqlContainerFixture()
        {
            Container = new ContainerBuilder<MsSqlContainer>()
                .ConfigureDockerImageName("mcr.microsoft.com/mssql/server:2017-latest-ubuntu")
                .ConfigureDatabaseConfiguration("not-used", Password, "not-used")
                .ConfigureLogging(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();
        }

        public Task InitializeAsync()
        {
            return Container.StartAsync();
        }

        public Task DisposeAsync()
        {
            return Container.StopAsync();
        }
    }
}