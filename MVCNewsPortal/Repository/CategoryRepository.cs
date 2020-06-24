using Microsoft.EntityFrameworkCore;
using MVCNewsPortal.Data;
using MVCNewsPortal.interfaces;
using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Repository
{
    public class CategoryRepository : INewsCategory
    {
        private readonly DBContext dBContext;

        public CategoryRepository(DBContext dBContent)
        {
            this.dBContext = dBContent;
        }
        public IEnumerable<Category> AllCategories => dBContext.Category;
    }
}
