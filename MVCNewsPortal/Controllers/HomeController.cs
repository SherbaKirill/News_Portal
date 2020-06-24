using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MVCNewsPortal.interfaces;
using MVCNewsPortal.Models;

namespace MVCNewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllNews _allNews;
        private readonly INewsCategory _newsCategory;
        public HomeController(ILogger<HomeController> logger, IAllNews allNews, INewsCategory newsCategory)
        {
            _logger = logger;
            _allNews = allNews;
            _newsCategory = newsCategory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("News/List")]
        [Route("News/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<News> news = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                news = _allNews.News.OrderBy(i => i.Id);
                currCategory = "Все новости";
            }
            else {
                if (_newsCategory.AllCategories.Any(x=>x.CategoryName==_category))
                {
                    news = _allNews.News.Where(i => i.Category.CategoryName == _category).OrderBy(i => i.Id);

                    currCategory = _newsCategory.AllCategories.Where(x => x.CategoryName == _category).Last().DisplayName;
                }
            }
            ViewBag.Title = "Новости";
            var obj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
