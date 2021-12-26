using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using PClub.Backend.Auth.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PClub.Backend.Auth.Config
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager<AppIdentityUser> _userManager;

        public CustomProfileService(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("SecondName", user.SecondName),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim("Role", (await _userManager.GetRolesAsync(user)).First())
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }
    }
}
