using BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public  interface ISearchNewsService
    {
        public Task<IEnumerable<NewsDomain>> GetNews();
        public Task<IEnumerable<NewsDomain>> GetNewsByCategory(string category);
        public Task<NewsDomain> GetNewsById(int? Id);
    }
}
