using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Service
{
    public class NewsService:INewsService
    {
        private readonly IRepository<News> _allNews;
        private readonly IRepository<Category> _allCategory;
        public NewsService(IRepository<News> repository,IRepository<Category> category)
        {
            _allNews = repository;
            _allCategory = category;
        }
        public NewsDTO Create(NewsDTO news)
        {
            if (news == null)
                throw new Exception("отсутствует");
            return news.ToNewsDTO(_allNews.Create(news.ToNews()).Result);

        }
        public NewsDTO Update(NewsDTO news)
        {
            _allNews.Update(news.ToNews());
            return news;
        }
        public void Delete(int Id)
        {
            _allNews.Delete(Id);
        }
    }
}
