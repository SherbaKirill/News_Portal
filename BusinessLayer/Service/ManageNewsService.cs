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
        private readonly IManageCategoryService _manageCategoryService;

        public ManageNewsService(IRepository<News> repository, ISearchCategoryService CategoryRepository,IManageCategoryService manageCategory)
        {
            _allNews = repository;
            _searchCategory = CategoryRepository;
            _manageCategoryService = manageCategory;
        }

        public async Task<NewsDomain> Create(NewsDomain news)
        {
            var category =(await _searchCategory.GetCategories()).Where(i => i.CategoryName == news.Category.CategoryName).FirstOrDefault();
            if (category == null)
               await _manageCategoryService.Create(news.Category);

            if (news == null)
                throw new Exception("отсутствует");

            return news.ToNewsDomain(await _allNews.Create(news.ToNews()));

        }

        public async Task<NewsDomain> Update(NewsDomain news)
        {
           var result =await _allNews.Update(news.ToNews());
            return news.ToNewsDomain(result);
        }
        public void Delete(int Id)
        {
            _allNews.Delete(Id);
        }
    }
}
