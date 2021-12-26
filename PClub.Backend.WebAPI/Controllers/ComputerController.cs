using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.DataAccess;
using PClub.Backend.WebAPI.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер управления компьютерами
    /// </summary>
    [Route("api/computer")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly PClubDbContext _context;

        public ComputerController(IUserService userService, PClubDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        /// <summary>
        /// Получить все компьютеры
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Computer>> GetComputers()
        {
            return await _context.Computers.ToListAsync();
        }
    }
}
