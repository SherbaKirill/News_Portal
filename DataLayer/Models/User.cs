using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models
{
    public class User: IdentityUser
    {
        public string Image { get; set; }
    }
}
