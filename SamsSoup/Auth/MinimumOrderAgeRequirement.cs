using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SamsSoup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SamsSoup.Auth
{
    public class MinimumOrderAgeRequirementHandler : AuthorizationHandler<MinimumOrderAgeRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MinimumOrderAgeRequirementHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumOrderAgeRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            var birthDate = user.BirthDate;

            var ageInYears = DateTime.Today.Year - birthDate.Year;

            if(ageInYears >= requirement.MinimumOrderAge)
            {
                context.Succeed(requirement);
            }
        }
    }

    public class MinimumOrderAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumOrderAge { get; }

        public MinimumOrderAgeRequirement(int minimumOrderAge)
        {
            MinimumOrderAge = minimumOrderAge;
        }
    }
}
