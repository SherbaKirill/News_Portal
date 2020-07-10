using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.Models
{
    public class UserViewModel : IdentityUser
    {
        public string Image { get; set; }
    }
}
