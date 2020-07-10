using BusinessLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IManageCategoryService
    {
        Task<CategoryDomain> Create(CategoryDomain obj);
        Task<CategoryDomain> Update(CategoryDomain obj);
        void Delete(int Id);
    }
}
