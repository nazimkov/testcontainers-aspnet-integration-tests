using IntegrationContainers.Data;

namespace IntegrationContainers.API.Tests.Fixtures
{
    public class TestContextConfiguration : IContextConfiguration
    {
        public TestContextConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}