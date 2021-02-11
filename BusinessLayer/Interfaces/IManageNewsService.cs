using BusinessLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IManageNewsService
    {
        Task<NewsDomain> Create(NewsDomain obj);
        Task<NewsDomain> Update(NewsDomain obj);
        void Delete(int Id);
    }
}
