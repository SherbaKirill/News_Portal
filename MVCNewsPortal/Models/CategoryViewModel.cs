using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        public string CategoryName { get; set; }

        public CategoryDTO ToCategoryDTO()
        {
            return new CategoryDTO { DisplayName = DisplayName, CategoryName = CategoryName };
        }
        public CategoryViewModel ToCategoryViewModel(CategoryDTO obj)
        {
            return new CategoryViewModel { CategoryName = obj.CategoryName, DisplayName = obj.DisplayName };
        }

    }
}
