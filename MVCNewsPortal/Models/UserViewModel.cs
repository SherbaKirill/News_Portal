using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCNewsPortal.Models
{
    public class UserViewModel : IdentityUser
    {
        public string Img { get; set; }
    }
}
