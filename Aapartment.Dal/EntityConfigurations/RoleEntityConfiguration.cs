using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>()
                {
                    Name = "ADMIN",
                    NormalizedName = "ADMIN",
                    Id = 1,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole<int>()
                {
                    Name = "GUEST",
                    NormalizedName = "GUEST",
                    Id = 2,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
}
