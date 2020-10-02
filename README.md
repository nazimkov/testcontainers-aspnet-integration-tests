# testcontainers-aspnet-integration-tests
[![Build status](https://ci.appveyor.com/api/projects/status/2xd5wkyy9laelcow?svg=true)](https://ci.appveyor.com/project/nazimkov/testcontainers-aspnet-integration-tests)

.NET Core 3.1 API + EF Core + MSSQL example application which utilize integration testing using Docker containers for throwaway DB instance. 

The integration testing implemented with help of:

1. [Testcontainers](https://github.com/isen-ng/testcontainers-dotnet	) -  is a .NET standard 2.0 library that supports NUnit and XUnit tests, providing lightweight, throwaway instances of common databases or anything else that can run in a Docker container. 
2. [XUnit](https://github.com/xunit/xunit) - xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework.
3. [TestServe](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1#aspnet-core-integration-tests)r - the test web host and in-memory test server, are provided or managed by the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package. Use of this package streamlines test creation and execution.
4. [Respawn](https://github.com/jbogard/Respawn) - is a small utility to help in resetting test databases to a clean state. Instead of deleting data at the end of a test or rolling back a transaction, Respawn [resets the database back to a clean checkpoint](http://lostechies.com/jimmybogard/2013/06/18/strategies-for-isolating-the-database-in-tests/) by intelligently deleting data from tables.

## Project structure

1. `IntegrationContainers.API` - .NET Core 3.1 API 
2. `IntegrationContainers.Data` - sort of Data Access Layer with EF Core Db Context , entities, migrations
3. `IntegrationContainers.API.Tests` - integration tests with fixtures setup

## Setup

Before running unit tests:

1. Install docker https://docs.docker.com/get-docker/

2. Pull SQL Server image:

   ```docker pull mcr.microsoft.com/mssql/server:2017-latest-ubuntu```