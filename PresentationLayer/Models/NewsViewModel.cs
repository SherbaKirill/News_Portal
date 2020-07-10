using BusinessLayer.Models;

namespace PresentationLayer.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public CategoryViewModel Category { get; set; } = new CategoryViewModel { CategoryName = "All", DisplayName = "Все новости" };

        public NewsDomain ToNewsDomain()
        {
            return new NewsDomain { Category = Category.ToCategoryDomain(), Id = Id, Name = Name, Image = Image, Content = Content, Description = Description };
        }
        public NewsViewModel ToNewsViewModel(NewsDomain obj)
        {
            return new NewsViewModel { Category = new CategoryViewModel().ToCategoryViewModel(obj.Category), Id = obj.Id, Name = obj.Name, Image = obj.Image, Content = obj.Content, Description = obj.Description };
        }
    }
}
