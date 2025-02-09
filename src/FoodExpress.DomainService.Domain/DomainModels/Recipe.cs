namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class Recipe : BaseEntity
    {
        public int MenuPositionId { get; set; }

        public int ProductGroupId { get; set; }

        public bool IsRequired { get; set; }

        public MenuPosition MenuPosition { get; set; } = null!;

        public ProductGroup ProductGroup { get; set; } = null!;

        public ICollection<MenuPositionProduct> MenuPositionProducts { get; set; } = new List<MenuPositionProduct>();

        public ICollection<OrderItemDetails> OrderItemDetails { get; set; } = new List<OrderItemDetails>();
    }
}
