using FoodExpress.DomainService.Api.Controllers;
using FoodExpress.DomainService.Api.Services;
using Moq;

namespace FoodExpress.DomainService.UnitTests.Controllers.OrdersControllerTests
{
    public abstract class OrdersControllerTestsBase
    {
        protected readonly Mock<IOrderService> _mockOrderService;
        protected readonly OrdersController _controller;

        public OrdersControllerTestsBase()
        {
            _mockOrderService = new Mock<IOrderService>();
            _controller = new OrdersController(_mockOrderService.Object);
        }
    }
}
