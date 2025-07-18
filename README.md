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
ASPNETCORE_ENVIRONMENT=Development dotnet run --project BcodeSeed.Api
```

By default the API listens on `http://localhost:5000`. Swagger UI is available at `http://localhost:5000/swagger` when `ASPNETCORE_ENVIRONMENT` is set to `Development`.

### Configuring the Listening Port

You can override the port by setting the `Urls` configuration value or the `PORT` environment variable. For example:

```bash
export PORT=8080
dotnet run --project BcodeSeed.Api
```

Alternatively, edit `appsettings.json` and change the `Urls` setting:

```json
{
  "Urls": "http://localhost:8080"
}
```

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
An additional integration test `WeatherForecastEndpointTests` located in `BcodeSeed.Tests/Integration` verifies that the `/weatherforecast` endpoint responds with HTTP `200`.

## Getting Started

Once the application is running, you can query the sample endpoint. The example below retrieves five random weather forecasts:

```bash
curl http://localhost:5000/weatherforecast
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
docker run -e PORT=8080 -e ASPNETCORE_ENVIRONMENT=Development -p 8080:8080 bcode-seed-api
```

The `PORT` environment variable controls which port the application listens on inside the container. The API will then be reachable at `http://localhost:8080`. Set `ASPNETCORE_ENVIRONMENT=Development` to enable Swagger UI at `http://localhost:8080/swagger`.

Any other port can be chosen by setting `PORT` to a different value and adjusting the host mapping passed to `-p`.


## Docker Compose

`docker-compose.yml` can run the API together with a PostgreSQL database. Add the `PORT` and `ASPNETCORE_ENVIRONMENT` variables to the `api` service so the internal port matches the exposed one and Swagger is enabled:

```yaml
services:
  api:
    build: .
    environment:
      - PORT=8080
      - ASPNETCORE_ENVIRONMENT=Development
    ports:
      - "8080:8080"
  db:
    # ...
```

Start the full stack with:

```bash
docker compose up
```

The API will be available at `http://localhost:8080` and the database will listen on port `5432`. Set `ASPNETCORE_ENVIRONMENT=Development` so the `/swagger` endpoint is enabled. Ensure the port mapping matches the `PORT` value. Any port can be used by changing both the `PORT` value and host mapping.
