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
        private readonly DBContext dBContext;

        public NewsRepository(DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }
        public async Task<News> Read(int id)
        {
            News news = await dBContext.News.FindAsync(id);
            if (news == null)
                return new News();
            return news;
        }
        public async Task<IQueryable<News>> ReadAll()
        {
            IQueryable<News> news = dBContext.News;
            return news;
        }
        public async Task<News> Create(News model)
        {
            if (dBContext.Category.AnyAsync(c => c.CategoryName == model.Category.CategoryName).Result)
                dBContext.Category.Add(model.Category);
            dBContext.News.Add(model);
            await dBContext.SaveChangesAsync();
            return model;
        }
        public async Task<News> Delete(int id)
        {
            News news = await dBContext.News.FindAsync(id);
            if (news == null)
                return new News();
            dBContext.News.Remove(news);
            await dBContext.SaveChangesAsync();
            return news;
        }
        public async Task<News> Update(News model)
        {
            News news = await dBContext.News.FindAsync(model.Id);
            if (news == null)
                await Create(model);
            else
            {
                dBContext.Entry(model).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
            }
            return model;
        }
    }
}
