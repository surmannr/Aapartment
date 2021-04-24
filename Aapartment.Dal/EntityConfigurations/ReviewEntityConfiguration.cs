using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(

                new Review()
                {
                    Stars = 4,
                    ApartmentId = 1,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 1,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 2,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 2,
                    UserId = 3
                }, 
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 3,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 3,
                    UserId = 4
                }
            );
        }
    }
}
