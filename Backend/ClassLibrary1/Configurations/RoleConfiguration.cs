using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>{ 
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper()
                },
                new IdentityRole<int>{
                    Id = 2,
                    Name = "user",
                    NormalizedName = "user".ToUpper()  
                });
        }
    }
}
