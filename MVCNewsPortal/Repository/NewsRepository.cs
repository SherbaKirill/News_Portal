using Microsoft.EntityFrameworkCore;
using MVCNewsPortal;
using MVCNewsPortal.Data;
using MVCNewsPortal.interfaces;
using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Repository
{
    public class NewsRepository : IAllNews
    {
        private readonly DBContext dBContext;

        public NewsRepository(DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }
        public IEnumerable<News> News => dBContext.News.Include(c => c.Category);

        public News GetNews(int newsId) => dBContext.News.FirstOrDefault(c => c.Id == newsId);
    }
}
