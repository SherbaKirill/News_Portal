using BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ISearchCategoryService
    {
        public Task<IEnumerable<CategoryDomain>> GetCategories();
        public Task<CategoryDomain> GetCategoryById(int? Id);
    }
}
