using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ManageNewsService:IManageNewsService
    {
        private readonly IRepository<News> _allNews;
        private readonly ISearchCategoryService _searchCategory;
        private readonly IManageCategoryService manageCategoryService;

        public ManageNewsService(IRepository<News> repository, ISearchCategoryService CategoryRepository,IManageCategoryService manageCategory)
        {
            _allNews = repository;
            _searchCategory = CategoryRepository;
            manageCategoryService = manageCategory;
        }

        public async Task<NewsDomain> Create(NewsDomain news)
        {
            var category = _searchCategory.GetCategories().Result.Where(i => i.CategoryName == news.Category.CategoryName).FirstOrDefault();
            if (category == null)
               await manageCategoryService.Create(news.Category);

            if (news == null)
                throw new Exception("отсутствует");

            return news.ToNewsDomain(_allNews.Create(news.ToNews()).Result);

        }

        public async Task<NewsDomain> Update(NewsDomain news)
        {
           await _allNews.Update(news.ToNews());
            return news;
        }
        public void Delete(int Id)
        {
            _allNews.Delete(Id);
        }
    }
}
