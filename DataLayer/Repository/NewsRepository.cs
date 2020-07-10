using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class NewsRepository : IRepository<News>
    {
        private readonly IRepository<Category> repository;
        private readonly DBContext dBContext;

        public NewsRepository(DBContext dBContext,IRepository<Category> repository) 
        {
            this.dBContext = dBContext;
            this.repository = repository;
        }
        public async Task<News> Read(int id)
        {
            News news = dBContext.News.Include(c=>c.Category).Where(c=>c.Id==id).First();
            if (news == null)
                return new News();

            return news;
        }
        public async Task<IQueryable<News>> ReadAll()
        {
            return dBContext.News.Include(c=>c.Category);
        }
        public async Task<News> Create(News model)
        {
            model.Category = dBContext.Category.Where(c => c.CategoryName == model.Category.CategoryName).First();
            dBContext.News.Add(model);
            await dBContext.SaveChangesAsync();
            return model;
        }
        public async Task<News> Delete(int id)
        {
            News news = dBContext.News.Find(id);
            if (news == null)
                return new News();

            dBContext.News.Remove(news);
            dBContext.SaveChanges();
            return news;
        }
        public async Task<News> Update(News model)
        {
            News news = dBContext.News.Where(c => c.Id == model.Id).First();
            news.Update(model);
            dBContext.SaveChanges();
            return dBContext.News.Where(c=>c.Id==news.Id).First();
        }
    }
}
