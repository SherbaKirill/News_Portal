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
using WebLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebLayer.Controllers
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

            return View(mapper.Map<IEnumerable<NewsDomain>, List<NewsViewModel>>(await _searchNews.GetNews()));
        }

        [Route("News/List/{category}")]
        public async Task<IActionResult> List(string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDomain, NewsViewModel>()
                .ForPath( c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
                .ForPath( c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();

            return View(mapper.Map<IEnumerable<NewsDomain>, List<NewsViewModel>>(await _searchNews.GetNewsByCategory(category)));
        }

        [Route("News/NewsId")]
        [Route("News/NewsId/{Id}")]
        public async Task<IActionResult> NewsId(int? Id)
        {
            try
            {
                var newsDomain = await _searchNews.GetNewsById(Id);
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
        public async Task<IActionResult> CreateNews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDomain, CategoryViewModel>()).CreateMapper();
            return View(mapper.Map<IEnumerable<CategoryDomain>, List<CategoryViewModel>>(await _searchCategory.GetCategories()));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public async Task<IActionResult> CreateNews(NewsViewModel news)
        {
            var newsDomain =await _newsService.Create(news.ToNewsDomain());
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain).Id });
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public async Task<IActionResult> UpdateNews(int Id)
        {
            var newsDomain = await _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel( newsDomain));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public async Task<IActionResult> UpdateNews(NewsViewModel news)
        {
            var newsDomain = await _newsService.Update(news.ToNewsDomain());
            news.ToNewsViewModel(newsDomain);
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDomain).Id });
        }

        [Authorize(Roles = "admin,moderator")]
        public async Task<IActionResult> DeleteNews(int Id)
        {
            var newsDomain = await _searchNews.GetNewsById(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDomain));
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
        public async Task<IActionResult> CreateCategory(CategoryViewModel category)
        {
            await _categoryService.Create(category.ToCategoryDomain());
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int Id)
        {
            var categoryDomain = await _searchCategory.GetCategoryById(Id);
            return View(new CategoryViewModel().ToCategoryViewModel(categoryDomain));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel category)
        {
            var categoryDomain = await _categoryService.Update(category.ToCategoryDomain());
            category.ToCategoryViewModel(categoryDomain);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin,moderator")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var categoryDomain = await _searchCategory.GetCategoryById(Id);
            return View(new CategoryViewModel().ToCategoryViewModel(categoryDomain));
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
