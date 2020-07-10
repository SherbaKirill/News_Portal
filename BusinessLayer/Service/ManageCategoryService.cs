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

            return await Task.Run(() => category.ToCategoryDomain(_allCategory.Create(category.ToCategory()).Result));
        }

        public async Task<CategoryDomain> Update(CategoryDomain category)
        {
            await _allCategory.Update(category.ToCategory());
            return category;
        }

        public void Delete(int Id)
        {
            _allCategory.Delete(Id);
        }
    }
}
