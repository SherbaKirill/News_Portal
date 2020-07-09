using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class ManageCategoryService: IManageCategoryService
    {
        private readonly IRepository<Category> _allCategory;
        public ManageCategoryService(IRepository<Category> repository)
        {
            _allCategory = repository;
        }
        public CategoryDomain Create(CategoryDomain category)
        {
            if (category == null)
                throw new Exception("отсутствует");
            return category.ToCategoryDomain(_allCategory.Create(category.ToCategory()).Result);

        }
        public CategoryDomain Update(CategoryDomain category)
        {
            _allCategory.Update(category.ToCategory());
            return category;
        }
        public void Delete(int Id)
        {
            _allCategory.Delete(Id);
        }
    }
}
