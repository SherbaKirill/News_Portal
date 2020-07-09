using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IManageCategoryService
    {
        CategoryDomain Create(CategoryDomain obj);
        CategoryDomain Update(CategoryDomain obj);
        void Delete(int Id);
    }
}
