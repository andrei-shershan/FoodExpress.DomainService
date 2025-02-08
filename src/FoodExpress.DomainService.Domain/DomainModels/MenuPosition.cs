namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class MenuPosition : BaseDescriptiveNameEntity
    {
        public int MenuSubcategoryId { get; set; }

        public MenuSubcategory MenuSubcategory { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
