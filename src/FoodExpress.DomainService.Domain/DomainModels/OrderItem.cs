namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }

        public int MenuPositionId { get; set; }

        public MenuPosition MenuPosition { get; set; } = null!;

        public Order Order { get; set; } = null!;

        public ICollection<OrderItemDetails> OrderItemDetails{ get; set; } = new List<OrderItemDetails>();
    }
}
