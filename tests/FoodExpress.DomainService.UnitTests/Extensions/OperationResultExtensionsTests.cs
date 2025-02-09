using FoodExpress.DomainService.Api.Extensions;

namespace FoodExpress.DomainService.UnitTests.Extensions
{
    public class OperationResultExtensionsTests
    {
        [Fact]
        public void IsSingle_ReturnsTrue_WhenValueIsOne()
        {
            // Arrange
            int value = 1;

            // Act
            bool result = value.IsSingle();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        public void IsSingle_ReturnsFalse_WhenValueIsNotOne(int value)
        {
            // Act
            bool result = value.IsSingle();

            // Assert
            Assert.False(result);
        }
    }
}

