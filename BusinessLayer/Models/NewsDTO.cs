using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class NewsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Img { get; set; }
        public CategoryDTO Category { get; set; }

        public News ToNews()
        {
            return new News { Img = Img, Id=Id, Category = Category.ToCategory(), Description = Description, Name = Name, Content = Content };
        }
        public NewsDTO ToNewsDTO(News obj)
        {
            return new NewsDTO { Category = new CategoryDTO().ToCategoryDTO(obj.Category), Id = obj.Id, Name = obj.Name, Img = obj.Img, Content = obj.Content, Description = obj.Description };
        }
    }
}
