using IntegrationContainers.Data;
using Microsoft.Extensions.Configuration;

namespace IntegrationContainers.API.Configs
{
    public class DataContextConfiguration : IContextConfiguration
    {
        public DataContextConfiguration(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("UsersDb");
        }

        public string ConnectionString { get; }
    }
}