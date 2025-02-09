namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class Product : BaseDescriptiveNameEntity
    {
        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; } = null!;

        public ICollection<MenuPositionProduct> MenuPositionProducts { get; set; } = new List<MenuPositionProduct>();

        public ICollection<OrderItemDetails> OrderItemDetails { get; set; } = new List<OrderItemDetails>();
    }
}
