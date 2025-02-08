namespace FoodExpress.DomainService.Domain.DomainModels
{
    public abstract class BaseDescriptiveNameEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
