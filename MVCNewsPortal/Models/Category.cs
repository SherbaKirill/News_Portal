using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        public string CategoryName { get; set; }

        public List<News> News { get; set; }
    }
}
