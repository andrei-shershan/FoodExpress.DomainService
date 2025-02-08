using Microsoft.Extensions.Logging;
using Moq;

namespace FoodExpress.DomainService.Api.Controllers.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly Mock<ILogger<WeatherForecastController>> _loggerMock;
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_loggerMock.Object);
        }

        [Fact]
        public void Get_ReturnsCorrectNumberOfForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_ReturnsValidDateRange()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            var today = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(today.AddDays(i + 1), result[i].Date);
            }
        }

        [Fact]
        public void Get_ReturnsValidTemperatureRange()
        {
            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
            }
        }

        [Fact]
        public void Get_ReturnsSummaryFromPredefinedList()
        {
            // Arrange
            var validSummaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild",
                "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.Contains(forecast.Summary, validSummaries);
            }
        }
    }
}