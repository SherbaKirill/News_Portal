using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class NewsDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public CategoryDomain Category { get; set; }

        public News ToNews()
        {
            return new News { Image = Image, Id=Id, Category = Category.ToCategory(), Description = Description, Name = Name, Content = Content };
        }
        public NewsDomain ToNewsDomain(News obj)
        {
            return new NewsDomain { Category = new CategoryDomain().ToCategoryDomain(obj.Category), Id = obj.Id, Name = obj.Name, Image = obj.Image, Content = obj.Content, Description = obj.Description };
        }
    }
}
