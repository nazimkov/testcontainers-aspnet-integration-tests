using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationContainers.API.Tests.Fixtures
{
    [CollectionDefinition("Integration containers collection")]
    public class IntegrationContainersCollection : ICollectionFixture<IntegrationContainersAppFactory>
    {
    }
}