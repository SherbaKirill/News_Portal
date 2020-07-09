using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CategoryDomain
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CategoryName { get; set; }
        public Category ToCategory()
        {
            return new Category { DisplayName = DisplayName, CategoryName = CategoryName, Id = Id };
        }
        public CategoryDomain ToCategoryDomain(Category obj)
        {
            return new CategoryDomain { CategoryName = obj.CategoryName, DisplayName = obj.DisplayName, Id=obj.Id};
        }
    }
}
