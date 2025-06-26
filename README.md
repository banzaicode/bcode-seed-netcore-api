# Bcode Seed .NET Core API

This repository contains a minimal ASP.NET Core Web API used as a starting point for building REST services. It exposes a sample `WeatherForecast` endpoint and comes pre-configured with Swagger for interactive documentation.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or later
- `git` for cloning the repository

## Cloning the Repository

```bash
git clone <repository-url>
cd bcode-seed-netcore-api
```

## Building the Project

Run the following command to restore packages and build the solution:

```bash
dotnet build
```

## Running the API

Start the API locally using:

```bash
dotnet run --project BcodeSeed.Api
```

By default the API listens on `https://localhost:5001` (and `http://localhost:5000`). Swagger UI will be available at `https://localhost:5001/swagger`.

ASP.NET Core automatically loads configuration from `appsettings.json` and an
environment-specific file like `appsettings.Development.json` based on the value
of the `ASPNETCORE_ENVIRONMENT` environment variable.

## Error Handling

Unhandled exceptions are routed to a dedicated `/error` endpoint by
`app.UseExceptionHandler("/error")`. The endpoint returns an RFC 7807
problem response, ensuring clients receive consistent JSON error details.

## Testing

This repository already includes a small xUnit test project located in `BcodeSeed.Tests`. Run the tests with:

```bash
dotnet test
```

For an example of the testing approach, see the sample `WeatherForecastControllerTests` under `BcodeSeed.Tests/UnitTests`.

## Getting Started

Once the application is running, you can query the sample endpoint. The example below retrieves five random weather forecasts:

```bash
curl -k https://localhost:5001/weatherforecast
```

You should receive a JSON array containing the forecast data.


## Docker

This repository includes a `Dockerfile` for building and running the API in a container.

Build the image using:

```bash
docker build -t bcode-seed-api .
```

Run the container with:

```bash
docker run -p 8080:8080 bcode-seed-api
```

The API will then be reachable at `http://localhost:8080` with Swagger UI available at `http://localhost:8080/swagger`.

