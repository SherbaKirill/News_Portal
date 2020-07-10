using BusinessLayer.Models;

namespace WebLayer.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CategoryName { get; set; }

        public CategoryDomain ToCategoryDomain()
        {
            return new CategoryDomain { DisplayName = DisplayName, CategoryName = CategoryName , Id=Id};
        }

        public CategoryViewModel ToCategoryViewModel(CategoryDomain obj)
        {
            return new CategoryViewModel { CategoryName = obj.CategoryName, DisplayName = obj.DisplayName, Id=obj.Id};
        }

    }
}
