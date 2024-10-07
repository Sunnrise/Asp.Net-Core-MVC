using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Name = "User", 
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Name = "Editor", 
                    NormalizedName = "EDITOR",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Name = "Admin", 
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
}
