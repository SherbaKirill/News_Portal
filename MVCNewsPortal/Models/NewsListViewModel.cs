using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Models
{
    public class NewsListViewModel
    {
        public IEnumerable<News> AllNews { get; set; }

        public string currCategory { get; set; }

    }
}
