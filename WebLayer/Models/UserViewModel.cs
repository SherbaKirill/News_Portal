using Microsoft.AspNetCore.Identity;

namespace WebLayer.Models
{
    public class UserViewModel : IdentityUser
    {
        public string Image { get; set; }
    }
}
