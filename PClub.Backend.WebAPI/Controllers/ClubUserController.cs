using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер управления пользователями
    /// </summary>
    [Route("api/clubuser")]
    [ApiController]
    public class ClubUserController : ControllerBase
    {
        private readonly PClubDbContext _context;

        public ClubUserController(PClubDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("all-users")]
        public async Task<IEnumerable<ClubUser>> GetClubUsersAsync()
        {
            return await _context.ClubUsers
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.SecondName)
                .ToListAsync();
        }

        
    }
}
