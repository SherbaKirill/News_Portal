using DataLayer.Models;
using System.Linq;

namespace MVCNewsPortal.Models
{
    public class NewsListViewModel
    {
        public IQueryable<News> AllNews { get; set; }

        public string currCategory { get; set; }

    }
}
