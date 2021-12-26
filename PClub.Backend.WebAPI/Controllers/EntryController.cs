using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.DataAccess;
using PClub.Backend.WebAPI.Helpers;
using PClub.Backend.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер управления записями пользователей
    /// </summary>
    [Route("api/entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly PClubDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EntryController(PClubDbContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Пользовательские записи
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("user-entries")]
        public async Task<IEnumerable<EntryResponse>> GetUserEntries()
        {
            var user = _userService.GetUser();
            var entries = await _context.Entries
                .Where(x => x.ClubUserId == user.Id)
                .OrderBy(p => p.VisitStartDateTime)
                .ProjectTo<EntryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return entries;
        }

        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-entries")]
        public async Task<IEnumerable<EntryResponse>> GetAllEntries()
        {
            var user = _userService.GetUser();
            return await _context.Entries
                .OrderBy(p => p.VisitStartDateTime)
                .ProjectTo<EntryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Записи по компьютеру
        /// </summary>
        /// <param name="computerId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("entry-by-computer/{computerId}")]
        public async Task<IEnumerable<EntryResponse>> GetUserEntriesByComputer(long computerId)
        {
            var user = _userService.GetUser();
            return await _context.Entries
                .Where(x => x.ComputerId == computerId)
                .OrderBy(p => p.VisitStartDateTime)
                .ProjectTo<EntryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="entryDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("create-entry")]
        public async Task CreateEntry(EntryDto entryDto)
        {
            var entry = _mapper.Map<Entry>(entryDto);
            entry.ClubUserId = _userService.GetUser().Id;
            await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить одну из записей текущего пользователя
        /// </summary>
        /// <param name="entryId"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        [Authorize]
        [HttpDelete("delete-for-current-user")]
        public async Task DeleteEntryForUser(long entryId)
        {
            var user = _userService.GetUser();
            var dbEntry = await _context.Entries.Where(x => x.ClubUserId == user.Id).FirstOrDefaultAsync(p => p.Id == entryId);
            if (dbEntry == null) throw new System.Exception("Нет такой записи у текущего ползователя или вообще для удаления");
            _context.Entries.Remove(dbEntry);
        }

        /// <summary>
        /// Удалить любую запись
        /// </summary>
        /// <param name="entryId"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-any-user-entry")]
        public async Task DeleteAnyUserEntry(long entryId)
        {
            var user = _userService.GetUser();
            var dbEntry = await _context.Entries.FirstOrDefaultAsync(p => p.Id == entryId);
            if (dbEntry == null) throw new System.Exception("Нет такой записи у текущего ползователя или вообще для удаления");
            _context.Entries.Remove(dbEntry);
        }
    }
}
