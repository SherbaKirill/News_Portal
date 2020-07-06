using DataLayer.Models;
using System.Linq;

namespace BusinessLayer
{
    public class NewsListViewModel
    {
        public IQueryable<News> AllNews { get; set; }
        public string currCategory { get; set; } = "Все новости";

    }
}
