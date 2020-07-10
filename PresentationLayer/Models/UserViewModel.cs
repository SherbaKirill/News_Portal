using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class UserViewModel : IdentityUser
    {
        public string Img { get; set; }
    }
}
