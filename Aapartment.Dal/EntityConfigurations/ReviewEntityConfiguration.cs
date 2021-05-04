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
                },
                new Review()
                {
                    Stars = 5,
                    ApartmentId = 4,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 4,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 2,
                    ApartmentId = 5,
                    Content = "There are a lot of cockroach here!",
                    Created = DateTime.Now,
                    Id = 5,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 6,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 6,
                    UserId = 4
                },
                new Review()
                {
                    Stars = 4,
                    ApartmentId = 7,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 7,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 8,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 8,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 9,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 9,
                    UserId = 4
                },
                new Review()
                {
                    Stars = 4,
                    ApartmentId = 10,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 10,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 11,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 11,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 12,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 12,
                    UserId = 4
                },
                new Review()
                {
                    Stars = 4,
                    ApartmentId = 13,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 13,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 14,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 14,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 14,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 15,
                    UserId = 4
                },
                new Review()
                {
                    Stars = 4,
                    ApartmentId = 15,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 16,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 15,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 17,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 15,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 18,
                    UserId = 4
                },
                new Review()
                {
                    Stars = 4,
                    ApartmentId = 16,
                    Content = "One of the best apartment here.",
                    Created = DateTime.Now,
                    Id = 19,
                    UserId = 2
                },
                new Review()
                {
                    Stars = 1,
                    ApartmentId = 16,
                    Content = "There are a lot of bugs here!",
                    Created = DateTime.Now,
                    Id = 20,
                    UserId = 3
                },
                new Review()
                {
                    Stars = 3,
                    ApartmentId = 16,
                    Content = "I could find a better place, but it's ok.",
                    Created = DateTime.Now,
                    Id = 21,
                    UserId = 4
                }
            );
        }
    }
}
