using FoodExpress.DomainService.Api.Models;
using FoodExpress.DomainService.Api.Models.ResposneResultErros;
using FoodExpress.DomainService.Domain.DomainModels;

namespace FoodExpress.DomainService.Api.Services
{
    public interface IOrderService
    {
        Task<OperationResult<Order, GenericCreationError>> CreateOrderAsync();
    }
}
