using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;

namespace PClub.Backend.WebAPI.DataAccess
{
    public class PClubDbContext : DbContext, IPClubDbContext
    {
        public PClubDbContext(DbContextOptions<PClubDbContext> options) : base(options)
        {

        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<ClubUser> ClubUsers { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
