using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ISearchCategoryService
    {
        public IEnumerable<CategoryDomain> GetCategories();
        public CategoryDomain GetCategoryById(int? Id);
    }
}
