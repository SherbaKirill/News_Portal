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
    public class NewsService:IManageNewsService
    {
        private readonly IRepository<News> _allNews;
        public NewsService(IRepository<News> repository)
        {
            _allNews = repository;
        }
        public NewsDomain Create(NewsDomain news)
        {
            if (news == null)
                throw new Exception("отсутствует");
            return news.ToNewsDomain(_allNews.Create(news.ToNews()).Result);

        }
        public NewsDomain Update(NewsDomain news)
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
