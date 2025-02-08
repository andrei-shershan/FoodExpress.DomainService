namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class ProductGroup : BaseDescriptiveNameEntity
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
