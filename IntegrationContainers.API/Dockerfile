FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
WORKDIR /src
COPY ["IntegrationContainers.API/IntegrationContainers.API.csproj", "IntegrationContainers.API/"]
RUN dotnet restore "IntegrationContainers.API/IntegrationContainers.API.csproj"
COPY . .
WORKDIR "/src/IntegrationContainers.API"
RUN dotnet build "IntegrationContainers.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IntegrationContainers.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IntegrationContainers.API.dll"]