namespace FoodExpress.DomainService.Api.Services
{
    // TODO: Move to shared data package
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
