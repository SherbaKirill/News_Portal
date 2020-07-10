using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using MVCNewsPortal.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Service;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace MVCNewsPortal.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly ISearchNewsService _searchNews;
        private readonly ISearchCategoryService _searchCategory;
        private readonly IManageCategoryService _categoryService;
        private readonly IManageNewsService _newsService;
        public NewsController(ILogger<NewsController> logger,ISearchNewsService newsSearch,IManageNewsService newsService, ISearchCategoryService categorySearch,IManageCategoryService categoryService)
        {
            _logger = logger;
            _searchNews = newsSearch;
            _newsService = newsService;
            _searchCategory = categorySearch;
            _categoryService = categoryService;
        }
        public async Task<ViewResult> Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDomain, NewsViewModel>()
                .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
                .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();

            return View(mapper.Map<IEnumerable<NewsDomain>, List<NewsViewModel>>(await Task.Run(() => _searchNews.GetNews())));
        }

        [Route("News/List/{category}")]
        public async Task<IActionResult> List(string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDomain, NewsViewModel>()
                .ForPath( c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
                .ForPath( c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();

            return View(mapper.Map<IEnumerable<NewsDomain>, List<NewsViewModel>>(await Task.Run(() => _searchNews.GetNewsByCategory(category))));
        }
        [Route("News/NewsId")]
        [Route("News/NewsId/{Id}")]
        public async Task<IActionResult> NewsId(int? Id)
        {
            try
            {
                var newsDomain = await Task.Run(()=>_searchNews.GetNewsById(Id));
                return View(new NewsViewModel().ToNewsViewModel(newsDomain));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNews(NewsViewModel news)
        {
            var category = _searchCategory.GetCategories().Where(i => i.CategoryName == news.Category.CategoryName).FirstOrDefault();
            if (category == null)
                _categoryService.Create(news.Category.ToCategoryDomain());
            var newsDomain = _newsService.Create(news.ToNewsDomain());
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain).Id });
        }
        [HttpGet]
        public IActionResult UpdateNews(int Id)
        {
            var newsDomain = _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDomain));
        }
        [HttpPost]
        public IActionResult UpdateNews(NewsViewModel news)
        {
            var newsDomain = _newsService.Update(news.ToNewsDomain());
            news.ToNewsViewModel(newsDomain);
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain).Id });
        }
        public IActionResult DeleteNews(int Id)
        {
            var newsDomain = _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDomain));
        }
        [HttpPost]
        public IActionResult DeleteNews(bool Enable,int Id)
        {
            if(Enable)
            _newsService.Delete(Id);

            return RedirectToAction("Index");
        }

    }
}
