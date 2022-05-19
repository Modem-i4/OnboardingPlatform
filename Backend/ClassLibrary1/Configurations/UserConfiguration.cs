using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.CourseToUsers)
               .WithOne(u => u.User);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Email)
                .IsRequired();
        }
    }
}
