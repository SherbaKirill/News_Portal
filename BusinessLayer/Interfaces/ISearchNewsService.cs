using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public  interface ISearchNewsService
    {
        public IEnumerable<NewsDomain> GetNews();
        public IEnumerable<NewsDomain> GetNewsByCategory(string category);
        public NewsDomain GetNewsById(int? Id);
    }
}
