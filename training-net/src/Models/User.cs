using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models
{
    public class User : IdentityUser
    {
        public bool IsExternal { get; set; }
    }
}
