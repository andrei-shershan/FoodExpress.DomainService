namespace FoodExpress.DomainService.Api.Extensions
{
    public static class OperationResultExtensions
    {
        public static bool IsSingle(this int value) => value == 1;
    }
}
