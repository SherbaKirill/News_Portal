using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public  interface IReader
    {
        public IEnumerable<NewsDTO> GetNews();
        public IEnumerable<NewsDTO> GetNewsOfCategory(string category);
        public NewsDTO NewsId(int? Id);
    }
}
