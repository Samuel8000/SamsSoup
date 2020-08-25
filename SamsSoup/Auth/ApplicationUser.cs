using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();
    }
}
