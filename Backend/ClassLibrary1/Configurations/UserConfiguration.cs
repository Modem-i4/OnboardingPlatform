using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.HasData(
               new User
               {
                   Id = 1,
                   FirstName = "Sasha",
                   LastName = "WAWAWA",
                   UserName = "WAWAWA",
                   Email = "kripaknomer1@gmail.com",
                   NormalizedEmail = "KRIPAKNOMER1@GMAIL.COM",
                   PasswordHash = "string",
                   RegistrationDate = DateTime.UtcNow
               },
               new User
               {
                   Id = 2,
                   FirstName = "Seriy",
                   LastName = "Liashyk",
                   UserName = "Muzilko",
                   Email = "string@gmail.com",
                   NormalizedEmail = "STRING@GMAIL.COM",
                   PasswordHash = "string",
                   RegistrationDate = DateTime.UtcNow
               });
        }
    }
}
