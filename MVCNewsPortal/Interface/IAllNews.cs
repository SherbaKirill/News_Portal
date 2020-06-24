using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.interfaces
{
    public interface IAllNews
    {
        IEnumerable<News> News { get; }
        News GetNews(int newsId);

    }
}
