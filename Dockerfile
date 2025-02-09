FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and projects
COPY "FoodExpress.DomainService.sln" .
COPY ["src/FoodExpress.DomainService.Api/FoodExpress.DomainService.Api.csproj", "src/FoodExpress.DomainService.Api/"]
COPY ["src/FoodExpress.DomainService.Domain/FoodExpress.DomainService.Domain.csproj", "src/FoodExpress.DomainService.Domain/"]
COPY ["tests/FoodExpress.DomainService.UnitTests/FoodExpress.DomainService.UnitTests.csproj", "tests/FoodExpress.DomainService.UnitTests/"]
RUN dotnet restore "src/FoodExpress.DomainService.Api/FoodExpress.DomainService.Api.csproj"

# Copy full source and build
COPY . .
WORKDIR "/src/src/FoodExpress.DomainService.Api"
RUN dotnet build "FoodExpress.DomainService.Api.csproj" -c Release -o /app/build

# Add a stage for running tests
FROM build AS testrunner
WORKDIR /src/tests/FoodExpress.DomainService.UnitTests
RUN dotnet test "FoodExpress.DomainService.UnitTests.csproj" --logger:trx

FROM build AS publish
RUN dotnet publish "FoodExpress.DomainService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodExpress.DomainService.Api.dll"]