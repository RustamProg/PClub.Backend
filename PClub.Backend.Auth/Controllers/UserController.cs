using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PClub.Backend.Auth.Config;
using PClub.Backend.Auth.Entities;
using PClub.Backend.Auth.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PClub.Backend.Auth.Controllers
{
    /// <summary>
    /// Контроллер управления пользователями
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppIdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationRequest request)
        {
            var user = _mapper.Map<AppIdentityUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, request.Role);
            await _userManager.AddClaimsAsync(user, new Claim[]
            {
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.SecondName),
                new Claim(JwtClaimTypes.Role, request.Role),
            });

            return Ok(request);
        }
    }
}
