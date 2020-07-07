using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface INewsService
    {
        NewsDTO Create(NewsDTO obj);
        NewsDTO Update(NewsDTO obj);
        void Delete(int Id);
    }
}
