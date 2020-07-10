using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class SearchCategoryService:ISearchCategoryService
    {
        IRepository<Category> _newsCategory;
        public SearchCategoryService(IRepository<Category> newsCategory)
        {
            _newsCategory = newsCategory;
        }

        public async Task<IEnumerable<CategoryDomain>> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDomain>()).CreateMapper();

            return await Task.Run(()=>mapper.Map<IQueryable<Category>, List<CategoryDomain>>(_newsCategory.ReadAll().Result));
        }

        public async Task<CategoryDomain> GetCategoryById(int? Id)
        {
            if (Id == null)
                throw new Exception("id отсутствует");

            var category = await Task.Run(()=>_newsCategory.Read(Id.Value).Result);
            if (category == null)
                throw new Exception("id не обнаружен");

            var categoryDomain = new CategoryDomain().ToCategoryDomain(category);
            return categoryDomain;
        }
    }
}
