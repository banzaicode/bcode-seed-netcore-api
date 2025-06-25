# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY BcodeSeed.sln ./
COPY BcodeSeed.Api/BcodeSeed.Api.csproj BcodeSeed.Api/
RUN dotnet restore
COPY BcodeSeed.Api/ BcodeSeed.Api/
RUN dotnet publish BcodeSeed.Api/BcodeSeed.Api.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BcodeSeed.Api.dll"]
