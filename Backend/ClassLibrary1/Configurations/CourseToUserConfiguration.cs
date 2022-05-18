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
    public class CourseToUserConfiguration : IEntityTypeConfiguration<CourseToUser>
    {
        public void Configure(EntityTypeBuilder<CourseToUser> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.UserId });

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseToUsers)
                .HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CourseToUsers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
