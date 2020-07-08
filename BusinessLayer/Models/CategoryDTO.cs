using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CategoryName { get; set; }
        public Category ToCategory()
        {
            return new Category { DisplayName = DisplayName, CategoryName = CategoryName };
        }
        public CategoryDTO ToCategoryDTO(Category obj)
        {
            return new CategoryDTO { CategoryName = obj.CategoryName, DisplayName = obj.DisplayName };
        }
    }
}
