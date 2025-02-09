using FoodExpress.DomainService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodExpress.DomainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOrder()
        {
            var createOrderResult = await _orderService.CreateOrderAsync();
            if (createOrderResult.IsSuccess)
            {
                return Created(nameof(CreateOrder), createOrderResult.Result);
            }

            return BadRequest();
        }
    }
}
