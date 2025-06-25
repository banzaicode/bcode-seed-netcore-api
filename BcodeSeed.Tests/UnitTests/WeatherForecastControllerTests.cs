using BcodeSeed.Api.Controllers;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;
using Xunit;

namespace BcodeSeed.Tests.UnitTests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsFiveForecasts()
    {
        var controller = new WeatherForecastController(new NullLogger<WeatherForecastController>());
        var result = controller.Get();
        Assert.Equal(5, result.Count());
    }
}
