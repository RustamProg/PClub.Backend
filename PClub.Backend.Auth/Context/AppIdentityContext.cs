using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PClub.Backend.Auth.Config;
using PClub.Backend.Auth.Entities;

namespace PClub.Backend.Auth.Context
{
    public class AppIdentityContext : IdentityDbContext<AppIdentityUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
