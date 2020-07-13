using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
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
            News news = dBContext.News.Include(c=>c.Category).FirstOrDefault(c=>c.Id==id);
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
            model.Category = dBContext.Category.FirstOrDefault(c => c.CategoryName == model.Category.CategoryName);
            dBContext.News.Add(model);
            await dBContext.SaveChangesAsync();
            return model;
        }
        public void Delete(int id)
        {
            News news = dBContext.News.Find(id);
            if (news == null)
                return;

            dBContext.News.Remove(news);
            dBContext.SaveChanges();
            return;
        }
        public async Task<News> Update(News model)
        {
            News news = dBContext.News.Include(c => c.Category).First(c => c.Id == model.Id);
            news.Update(model);
            await dBContext.SaveChangesAsync();
            return news;
        }
    }
}
