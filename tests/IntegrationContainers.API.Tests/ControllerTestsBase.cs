using IntegrationContainers.API.Tests.Fixtures;
using IntegrationContainers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationContainers.API.Tests
{
    public abstract class ControllerTestsBase : IAsyncLifetime
    {
        protected HttpClient Client { get; }
        protected UsersDataContext Context { get; }

        private readonly IServiceScope _scope;
        private readonly Checkpoint _checkpoint;
        private readonly string _connectionString;
        private object _lockObject = new object();


        public ControllerTestsBase(IntegrationContainersAppFactory integrationContainersFixture)
        {
            Client = integrationContainersFixture.CreateClient();
            _scope = integrationContainersFixture.Server.Host.Services.CreateScope();
            _connectionString = integrationContainersFixture.ConnectionString;
            _checkpoint = new Checkpoint();
            Context = _scope.ServiceProvider.GetRequiredService<UsersDataContext>();
        }

        public Task InitializeAsync()
        {
            // TODO get rid of lock
            lock(_lockObject)
            {
                Context.Database.Migrate();
            }
            return _checkpoint.Reset(_connectionString);
        }

        public Task DisposeAsync()
        {
            _scope.Dispose();
            return Task.CompletedTask;
        }
    }
}