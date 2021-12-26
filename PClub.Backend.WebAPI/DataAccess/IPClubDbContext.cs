using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.DataAccess
{
    public interface IPClubDbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ClubUser> ClubUsers { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
