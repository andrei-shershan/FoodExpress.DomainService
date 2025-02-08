namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class MenuCategory : BaseDescriptiveNameEntity
    { 
        public ICollection<MenuSubcategory> MenuSubcategories { get; set; } = new List<MenuSubcategory>();
    }
}
