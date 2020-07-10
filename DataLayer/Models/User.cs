using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User: IdentityUser
    {
        public string img { get; set; }
    }
}
