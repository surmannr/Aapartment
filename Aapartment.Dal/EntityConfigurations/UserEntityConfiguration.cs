using Aapartment.Dal.Entities;
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
            builder.HasData(
                new User()
                {
                    LastName = "Barta",
                    FirstName = "Botond",
                    Email = "bbotond25@gmail.com",
                    Id = 2,
                    PhoneNumber = "06/30-152-5123",
                    EmailConfirmed = true,
                    UserName = "baaart",
                    PasswordHash = "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw=="
                },
                new User()
                {
                    LastName = "Máté",
                    FirstName = "Herczku",
                    Email = "hmate@gmail.com",
                    Id = 3,
                    PhoneNumber = "06/30-152-5123",
                    EmailConfirmed = true,
                    UserName = "herczkum",
                    PasswordHash = "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw=="
                },
                new User()
                {
                    LastName = "Béla",
                    FirstName = "Kis",
                    Email = "kbela@gmail.com",
                    Id = 4,
                    PhoneNumber = "06/30-152-5123",
                    EmailConfirmed = true,
                    UserName = "kbela",
                    PasswordHash = "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw=="
                }
            );
        }
    }
}
