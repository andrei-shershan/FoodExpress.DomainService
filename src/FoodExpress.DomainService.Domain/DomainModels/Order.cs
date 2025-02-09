using FoodExpress.DomainService.Domain.Enums;

namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public DateTime CreateAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
