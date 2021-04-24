using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class IdentityUserRoleEntityConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<int>() { UserId = 2, RoleId = 2},
                 new IdentityUserRole<int>() { UserId = 3, RoleId = 2 },
                 new IdentityUserRole<int>() { UserId = 4, RoleId = 2 }
            );
        }
    }
}
