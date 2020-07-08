using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IManageNewsService
    {
        NewsDomain Create(NewsDomain obj);
        NewsDomain Update(NewsDomain obj);
        void Delete(int Id);
    }
}
