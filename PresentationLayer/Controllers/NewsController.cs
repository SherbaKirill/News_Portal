using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using AutoMapper;
using System.Collections.Generic;
using PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Controllers
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

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult CreateNews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDomain, CategoryViewModel>()).CreateMapper();
            return View(mapper.Map<IEnumerable<CategoryDomain>, List<CategoryViewModel>>(_searchCategory.GetCategories().Result));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult CreateNews(NewsViewModel news)
        {
            var newsDomain = _newsService.Create(news.ToNewsDomain());
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain.Result).Id });
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult UpdateNews(int Id)
        {
            var newsDomain = _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDomain.Result));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult UpdateNews(NewsViewModel news)
        {
            var newsDomain = _newsService.Update(news.ToNewsDomain());
            news.ToNewsViewModel(newsDomain.Result);
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain.Result).Id });
        }

        [Authorize(Roles = "admin,moderator")]
        public IActionResult DeleteNews(int Id)
        {
            var newsDomain = _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDomain.Result));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult DeleteNews(bool Enable,int Id)
        {
            if(Enable)
            _newsService.Delete(Id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel category)
        {
           _categoryService.Create(category.ToCategoryDomain());
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult UpdateCategory(int Id)
        {
            var categoryDomain = _searchCategory.GetCategoryById(Id);
            return View(new CategoryViewModel().ToCategoryViewModel(categoryDomain.Result));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel category)
        {
            var categoryDomain = _categoryService.Update(category.ToCategoryDomain());
            category.ToCategoryViewModel(categoryDomain.Result);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin,moderator")]
        public IActionResult DeleteCategory(int Id)
        {
            var categoryDomain = _searchCategory.GetCategoryById(Id);
            return View(new CategoryViewModel().ToCategoryViewModel(categoryDomain.Result));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult DeleteCategory(bool Enable, int Id)
        {
            if (Enable)
                _newsService.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
