using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents
{
    public class UserViewComponent:ViewComponent
    {
        UserManager<UserViewModel> _userManager;

        public UserViewComponent(UserManager<UserViewModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["id"] = _userManager.GetUserId(HttpContext.User);
            return View();
        }
    }
}
