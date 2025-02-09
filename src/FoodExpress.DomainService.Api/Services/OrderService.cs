using FoodExpress.DomainService.Api.Extensions;
using FoodExpress.DomainService.Api.Models;
using FoodExpress.DomainService.Api.Models.ResposneResultErros;
using FoodExpress.DomainService.Domain.Context;
using FoodExpress.DomainService.Domain.DomainModels;
using FoodExpress.DomainService.Domain.Enums;

namespace FoodExpress.DomainService.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly FoodExpressDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public OrderService(FoodExpressDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<OperationResult<Order, GenericCreationError>> CreateOrderAsync()
        {
            try
            {
                var createdOrder = await _dbContext.Orders.AddAsync(new Order()
                {
                    CreateAt = _dateTimeProvider.UtcNow,
                    Status = OrderStatus.New
                });

                var saveResult = await _dbContext.SaveChangesAsync();
                if (saveResult.IsSingle())
                {
                    return OperationResult<Order, GenericCreationError>.Success(createdOrder.Entity);
                }
            }
            catch (Exception ex)
            {
                // TODO: Handle exception
            }

            return OperationResult<Order, GenericCreationError>.Failure(GenericCreationError.CreationError);
        }
    }
}
