#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Movies/Movies.Aggregator.API/Movies.Aggregator.Api.csproj", "Movies/Movies.Aggregator.API/"]
COPY ["Shared/Api.Common/Api.Common.csproj", "Shared/Api.Common/"]
COPY ["Movies/Movies.Aggregator.Domain/Movies.Aggregator.Domain.csproj", "Movies/Movies.Aggregator.Domain/"]
COPY ["Shared/Cache/ServiceCache.csproj", "Shared/Cache/"]
COPY ["Shared/Cinema.Client/Cinema.Client.csproj", "Shared/Cinema.Client/"]
COPY ["Shared/Polly.Wrapper/Polly.Wrapper.csproj", "Shared/Polly.Wrapper/"]
COPY ["Shared/Movies.Client/Movies.Client.csproj", "Shared/Movies.Client/"]
RUN dotnet restore "./Movies/Movies.Aggregator.API/./Movies.Aggregator.Api.csproj"
COPY . .
WORKDIR "/src/Movies/Movies.Aggregator.API"
RUN dotnet build "./Movies.Aggregator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Movies.Aggregator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movies.Aggregator.Api.dll"]