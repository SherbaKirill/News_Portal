using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CUDNews:ICUDNews
    {
        private readonly IRepository<News> _allNews;
        public CUDNews(IRepository<News> repository)
        {
            _allNews = repository;
        }
        public News Create(string Name, string Description, string Contents, string Img, string Category)
        {
           return _allNews.Create(new News { Name=Name, Description = Description, Content = Contents, Img = Img, Category = new Category { CategoryName = Category, DisplayName=Category} }).Result;
        }
        public News Update(int Id, string Name, string Description, string Content, string Img, string Category)
        {
            News news = _allNews.Read(Id).Result;
            news.Name = Name?? news.Name ;
            news.Description = Description?? news.Description;
            news.Content = Content??news.Content;
            news.Img = Img?? news.Img;
            return _allNews.Update(news).Result;
        }
        public News Delete(int Id)
        {
            return _allNews.Delete(Id).Result;
        }
    }
}
