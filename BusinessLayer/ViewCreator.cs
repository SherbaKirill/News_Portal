using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class ViewCreator: IViewCreator
    {
        private readonly IRepository<News> _allNews;
        private readonly IRepository<Category> _newsCategory;
        public ViewCreator(IRepository<News> allNews, IRepository<Category> newsCategory)
        {
            _allNews = allNews;
            _newsCategory = newsCategory;
        }

        public  NewsListViewModel GetNews()
        {
            IQueryable<News> news = _allNews.ReadAll().Result;
            string currCategory = "Все новости";
            var obj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };
            return obj;
        }

        public NewsListViewModel CategoryNews(string category)
        {
            string _category = category;
            IQueryable<News> news = null;
            string currCategory = "";
            if (_newsCategory.ReadAll().Result.Any(x => x.CategoryName == _category))
            {
                news = _allNews.ReadAll().Result.Where(i => i.Category.CategoryName == _category).OrderByDescending(i => i.Id);
                currCategory = _newsCategory.ReadAll().Result.Where(x => x.CategoryName == _category).First().DisplayName;
            }
            var obj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };
            return obj;
        }
        public News NewsId(int Id = 1) => _allNews.Read(Id).Result;
    }
}
