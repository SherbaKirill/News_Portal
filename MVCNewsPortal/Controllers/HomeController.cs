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

namespace MVCNewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReader _reader;
        private readonly INewsService _newsService;
        public HomeController(ILogger<HomeController> logger,IReader reader,INewsService newsService)
        {
            _logger = logger;
            this._reader = reader;
            _newsService = newsService;
        }
        public async Task<ViewResult> Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>()
            .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
            .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();
            return View(mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(await Task.Run(() => _reader.GetNews())));
        }

        [Route("News/List/{category}")]
        public async Task<IActionResult> List(string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>()
            .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
            .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();
            return View(mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(await Task.Run(() => _reader.GetNewsOfCategory(category))));
        }
        [Route("News/NewsId")]
        [Route("News/NewsId/{Id}")]
        public async Task<IActionResult> NewsId(int? Id)
        {
            try
            {
                NewsDTO newsDTO =await Task.Run(()=>_reader.NewsId(Id));
                return View(new NewsViewModel().ToNewsViewModel(newsDTO));
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewsViewModel news)
        {
            NewsDTO newsDTO = _newsService.Create(news.ToNewsDTO());
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDTO).Id });
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            NewsDTO newsDTO =_reader.NewsId(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDTO));
        }
        [HttpPost]
        public IActionResult Update(NewsViewModel news)
        {
            NewsDTO newsDTO = _newsService.Update(news.ToNewsDTO());
            news.ToNewsViewModel(newsDTO);
            return RedirectToAction("NewsId", new { news.ToNewsViewModel(newsDTO).Id });
        }
        public IActionResult Delete(int Id)
        {
            NewsDTO newsDTO = _reader.NewsId(Id);
            return View(new NewsViewModel().ToNewsViewModel(newsDTO));
        }
        [HttpPost]
        public IActionResult Delete(bool Enable,int Id)
        {
            if(Enable)
            _newsService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
