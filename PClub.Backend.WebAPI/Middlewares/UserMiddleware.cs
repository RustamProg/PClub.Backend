using Microsoft.AspNetCore.Http;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.DataAccess;
using PClub.Backend.WebAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Middlewares
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        private PClubDbContext _dbContext;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, IUserService userService, PClubDbContext dbContext)
        {
            _dbContext = dbContext;
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            if (jsonToken != null)
            {
                var userId = jsonToken.Claims.First(x => x.Type == "sub").Value.Trim();
                var firstName = jsonToken.Claims.First(x => x.Type == "FirstName").Value.Trim();
                var secondName = jsonToken.Claims.First(x => x.Type == "SecondName").Value.Trim();
                var phoneNumber = jsonToken.Claims.First(x => x.Type == "PhoneNumber").Value.Trim();
                var email = jsonToken.Claims.First(x => x.Type == "Email").Value.Trim();
                var clubUser = new ClubUser { Id = System.Guid.Parse(userId), Email = email,  FirstName = firstName, SecondName = secondName, PhoneNumber = phoneNumber };
                userService.SetUser(clubUser);
                await TryAddUser(clubUser);
            }

            await _next(context);
        }

        private async Task TryAddUser(ClubUser user)
        {
            try
            {
                await _dbContext.ClubUsers.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch { }
        }
    }
}
