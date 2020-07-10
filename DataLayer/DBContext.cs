using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
