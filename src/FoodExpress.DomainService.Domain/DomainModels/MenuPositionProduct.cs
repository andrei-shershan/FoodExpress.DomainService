namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class MenuPositionProduct : BaseEntity
    {
        public int RecipeId { get; set; }
        
        public int ProductId { get; set; }

        public Recipe Recipe { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
