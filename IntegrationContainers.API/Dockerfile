FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["IntegrationContainers.API/IntegrationContainers.API.csproj", "IntegrationContainers.API/"]
COPY ["IntegrationContainers.Data/IntegrationContainers.Data.csproj", "IntegrationContainers.Data/"]
RUN dotnet restore "IntegrationContainers.API/IntegrationContainers.API.csproj"
COPY . .
WORKDIR "/src/IntegrationContainers.API"
RUN dotnet build "IntegrationContainers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationContainers.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationContainers.API.dll"]
