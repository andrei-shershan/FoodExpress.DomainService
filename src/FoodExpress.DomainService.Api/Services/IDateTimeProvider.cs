namespace FoodExpress.DomainService.Api.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
