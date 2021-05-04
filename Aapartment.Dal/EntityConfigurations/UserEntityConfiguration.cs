using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            PasswordHasher<User> ph = new PasswordHasher<User>();
            var user1 = new User()
            {
                LastName = "Elek",
                FirstName = "Teszt",
                Email = "tesztelek@gmail.com",
                NormalizedEmail = "tesztelek@gmail.com".ToUpper(),
                Id = 2,
                PhoneNumber = "06/30-152-5123",
                EmailConfirmed = true,
                UserName = "tesztelek",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "tesztelek".ToUpper()
            };
            
            var user2 = new User()
            {
                LastName = "Eszter",
                FirstName = "Winch",
                Email = "wincheszter@gmail.com",
                NormalizedEmail = "wincheszter@gmail.com".ToUpper(),
                Id = 3,
                PhoneNumber = "06/30-152-5123",
                EmailConfirmed = true,
                UserName = "wincheszter",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "wincheszter".ToUpper()
            };
            var user3 = new User()
            {
                LastName = "Béla",
                FirstName = "Kis",
                Email = "kbela@gmail.com",
                NormalizedEmail = "kbela@gmail.com".ToUpper(),
                Id = 4,
                PhoneNumber = "06/30-152-5123",
                EmailConfirmed = true,
                UserName = "kbela",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "kbela".ToUpper()
            };
            user1.PasswordHash = ph.HashPassword(user1, "asd123ASD?");
            user2.PasswordHash = ph.HashPassword(user2, "asd123ASD?");
            user3.PasswordHash = ph.HashPassword(user3, "asd123ASD?");
            builder.HasData(
                user1,user2,user3
            );
        }
    }
}
