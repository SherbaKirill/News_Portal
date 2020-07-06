using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using MVCNewsPortal.Models;
using BusinessLayer;

namespace MVCNewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewCreator _viewCreator;
        private readonly ICUDNews _CUDNews;
        public HomeController(ILogger<HomeController> logger,IViewCreator viewCreator,ICUDNews cUDNews)
        {
            _logger = logger;
            this._viewCreator = viewCreator;
            _CUDNews = cUDNews;
        }
        public async Task<ViewResult> Index()
        {
            return View(await Task.Run(()=>_viewCreator.GetNews()));
        }

        [Route("News/List/{category}")]
        public async Task<ViewResult> List(string category)
        {
            return View(await Task.Run(()=>_viewCreator.CategoryNews(category)));
        }
        [Route("News/NewsId")]
        [Route("News/NewsId/{Id}")]
        public async Task<ViewResult> NewsId(int Id=1)=> View(await Task.Run(()=>_viewCreator.NewsId(Id)));

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
        public IActionResult Create(string Name,string Description,string Contents,string Img,string Category="Все новости")
        {
            _CUDNews.Create(Name, Description, Contents, Img, Category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int Id,string Name, string Description, string Contents, string Img, string Category = "Все новости")
        {
            _CUDNews.Update(Id,Name, Description, Contents, Img, Category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _CUDNews.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
