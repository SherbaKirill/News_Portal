using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MVCNewsPortal.Models;

namespace MVCNewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<News> _allNews;
        private readonly IRepository<Category> _newsCategory;
        public HomeController(ILogger<HomeController> logger, IRepository<News> allNews, IRepository<Category> newsCategory)
        {
            _logger = logger;
            _allNews = allNews;
            _newsCategory = newsCategory;
        }
        public ViewResult Index()
        {
            IQueryable<News> news = _allNews.ReadAll().Result;
            string currCategory = "Все новости";
            var obj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };
            return View(obj);
        }

        [Route("News/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IQueryable<News> news = null;
            string currCategory = "";
            if (_newsCategory.ReadAll().Result.Any(x => x.CategoryName == _category))
            {
                news = _allNews.ReadAll().Result.Where(i => i.Category.CategoryName == _category).OrderByDescending(i => i.Id);
                currCategory = _newsCategory.ReadAll().Result.Where(x => x.CategoryName == _category).First().DisplayName;
            }
            var obj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };
            return View(obj);
        }
        [Route("News/NewsId")]
        [Route("News/NewsId/{Id}")]
        public ViewResult NewsId(int Id=1)=> View(_allNews.Read(Id).Result);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
