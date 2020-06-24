using Microsoft.EntityFrameworkCore;
using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Data
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
