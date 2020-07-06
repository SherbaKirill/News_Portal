using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ICUDNews
    {
        News Create(string Name, string Description, string Contents, string Img, string Category);
        News Update(int Id,string Name, string Description, string Contents, string Img, string Category);
        News Delete(int Id);
    }
}
