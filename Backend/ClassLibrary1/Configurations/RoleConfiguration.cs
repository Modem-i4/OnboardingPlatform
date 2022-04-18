using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "student",
                    NormalizedName = "student".ToUpper()
                });
        }
    }
}
