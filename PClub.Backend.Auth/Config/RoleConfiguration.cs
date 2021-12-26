using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PClub.Backend.Auth.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Id = "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                Name = "User",
                NormalizedName = "USER"
            });
        }
    }
}
