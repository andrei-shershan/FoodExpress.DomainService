namespace FoodExpress.DomainService.Domain.DomainModels
{
    public class MenuSubcategory : BaseDescriptiveNameEntity
    {
        public int MenuCategoryId { get; set; }

        public MenuCategory MenuCategory { get; set; } = null!;

        public ICollection<MenuPosition> MenuPositions { get; set; } = new List<MenuPosition>();

    }
}
