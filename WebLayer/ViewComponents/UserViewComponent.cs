using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;
using System.Threading.Tasks;

namespace WebLayer.ViewComponents
{
    public class UserViewComponent:ViewComponent
    {
        private readonly UserManager<UserViewModel> _userManager;

        public UserViewComponent(UserManager<UserViewModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserViewModel user =await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
    }
}
