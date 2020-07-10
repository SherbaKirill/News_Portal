using DataLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DBContext dBContext;

        public CategoryRepository(DBContext dBContent)
        {
            this.dBContext = dBContent;
        }
        public async Task<Category> Read(int id)
        {
            Category category = await dBContext.Category.FindAsync(id);
            if (category == null)
                return new Category();
            return category;
        }
        public async Task<IQueryable<Category>> ReadAll()
        {
            return dBContext.Category;
        }
        public async Task<Category> Create(Category model)
        {
            dBContext.Category.Add(model);
            await dBContext.SaveChangesAsync();
            return model;
        }
        public async Task<Category> Delete(int id)
        {
            Category category = await dBContext.Category.FindAsync(id);
            if (category == null)
                return new Category();
            dBContext.Category.Remove(category);
            dBContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category model)
        {
            Category category = await dBContext.Category.FindAsync(model.Id);
            category.Update(model);
            dBContext.SaveChangesAsync();
            return category;
        }
    }
}
