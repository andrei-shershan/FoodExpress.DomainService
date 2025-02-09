namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class OrderItemDetails : BaseEntity
    {
        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public int RecipeId { get; set; }

        public OrderItem OrderItem { get; set; } = null!;

        public Recipe Recipe { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
