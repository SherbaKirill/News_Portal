using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public  interface IViewCreator
    {
        public NewsListViewModel GetNews();

        public NewsListViewModel CategoryNews(string category);
        public News NewsId(int Id);
    }
}
