using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Img { get; set; }

        public CategoryViewModel Category { get; set; } = new CategoryViewModel { CategoryName = "All", DisplayName = "Все новости" };

        public NewsDTO ToNewsDTO()
        {
            return new NewsDTO { Category = Category.ToCategoryDTO(), Id = Id, Name = Name, Img = Img, Content = Content, Description = Description };
        }
        public NewsViewModel ToNewsViewModel(NewsDTO obj)
        {
            return new NewsViewModel { Category = new CategoryViewModel().ToCategoryViewModel(obj.Category), Id = obj.Id, Name = obj.Name, Img = obj.Img, Content = obj.Content, Description = obj.Description };
        }
    }
}
