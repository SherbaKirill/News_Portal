using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal.interfaces
{
    public interface INewsCategory
    {
        IEnumerable<Category> AllCategories { get; }

    }
}
