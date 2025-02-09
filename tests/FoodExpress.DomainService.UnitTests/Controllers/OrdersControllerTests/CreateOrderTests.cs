using FoodExpress.DomainService.Api.Models;
using FoodExpress.DomainService.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FoodExpress.DomainService.Api.Models.ResposneResultErros;

namespace FoodExpress.DomainService.UnitTests.Controllers.OrdersControllerTests
{
    public class CreateOrderTests : OrdersControllerTestsBase
    {
        [Fact]
        public async Task CreateOrder_ReturnsCreatedResult_WhenOrderIsCreatedSuccessfully()
        {
            // Arrange
            var order = new Order(); // Assuming Order is a valid class
            var createOrderResult = new OperationResult<Order, GenericCreationError> { IsSuccess = true, Result = order };

            _mockOrderService
                .Setup(service => service.CreateOrderAsync())
                .ReturnsAsync(createOrderResult);

            // Act
            var result = await _controller.CreateOrder();

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);

            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            Assert.Equal(order, createdResult.Value);
        }

        [Fact]
        public async Task CreateOrder_ReturnsBadRequest_WhenOrderCreationFails()
        {
            // Arrange
            var createOrderResult = new OperationResult<Order, GenericCreationError> { IsSuccess = false };

            _mockOrderService
                .Setup(service => service.CreateOrderAsync())
                .ReturnsAsync(createOrderResult);

            // Act
            var result = await _controller.CreateOrder();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);

            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        }
    }
}
