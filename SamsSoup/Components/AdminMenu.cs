using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem>
            { new AdminMenuItem()
            {
                DisplayValue = "User Management",
                ActionValue = "UserManagement"
            },
            new AdminMenuItem()
            {
                DisplayValue = "Role Management",
                ActionValue = "RoleManagement"
            }};

            return View(menuItems);
        }


    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
