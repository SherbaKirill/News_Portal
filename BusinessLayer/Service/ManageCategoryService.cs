using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ManageCategoryService: IManageCategoryService
    {
        private readonly IRepository<Category> _allCategory;

        public ManageCategoryService(IRepository<Category> repository)
        {
            _allCategory = repository;
        }

        public async Task<CategoryDomain> Create(CategoryDomain category)
        {
            if (category == null)
                throw new Exception("отсутствует");

            return category.ToCategoryDomain(await _allCategory.Create(category.ToCategory()));
        }

        public async Task<CategoryDomain> Update(CategoryDomain category)
        {
            var result=await _allCategory.Update(category.ToCategory());
            return category.ToCategoryDomain(result);
        }

        public void Delete(int id)
        {
            _allCategory.Delete(id);
        }
    }
}
