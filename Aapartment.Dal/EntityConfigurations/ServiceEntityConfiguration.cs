using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class ServiceEntityConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.OwnsMany(e => e.Services).HasData(
                new { Id = 1, ApartmentId = 1, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 2, ApartmentId = 1, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 3, ApartmentId = 1, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 4, ApartmentId = 1, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 5, ApartmentId = 1, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 6, ApartmentId = 1, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 7, ApartmentId = 2, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 8, ApartmentId = 2, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 9, ApartmentId = 2, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 10, ApartmentId = 2, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 11, ApartmentId = 2, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 12, ApartmentId = 2, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 13, ApartmentId = 3, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 14, ApartmentId = 3, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 15, ApartmentId = 3, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 16, ApartmentId = 3, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 17, ApartmentId = 3, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 18, ApartmentId = 3, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 19, ApartmentId = 4, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 20, ApartmentId = 4, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 21, ApartmentId = 4, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 22, ApartmentId = 4, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 23, ApartmentId = 4, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 24, ApartmentId = 4, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 25, ApartmentId = 5, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 26, ApartmentId = 5, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 27, ApartmentId = 5, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 28, ApartmentId = 6, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 29, ApartmentId = 6, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 30, ApartmentId = 6, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 31, ApartmentId = 6, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 32, ApartmentId = 7, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 33, ApartmentId = 7, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 34, ApartmentId = 7, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 35, ApartmentId = 7, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 36, ApartmentId = 7, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 37, ApartmentId = 7, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 38, ApartmentId = 8, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 39, ApartmentId = 8, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 40, ApartmentId = 8, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 41, ApartmentId = 8, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 42, ApartmentId = 9, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 43, ApartmentId = 9, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 44, ApartmentId = 9, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 45, ApartmentId = 9, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 46, ApartmentId = 9, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 47, ApartmentId = 10, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 48, ApartmentId = 10, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 49, ApartmentId = 10, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 50, ApartmentId = 10, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 51, ApartmentId = 11, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 52, ApartmentId = 11, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 53, ApartmentId = 11, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 54, ApartmentId = 11, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 55, ApartmentId = 11, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 56, ApartmentId = 12, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 57, ApartmentId = 12, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 58, ApartmentId = 12, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 59, ApartmentId = 12, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 60, ApartmentId = 12, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 61, ApartmentId = 13, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 62, ApartmentId = 14, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 63, ApartmentId = 14, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 64, ApartmentId = 15, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 65, ApartmentId = 15, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 66, ApartmentId = 15, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new { Id = 67, ApartmentId = 15, Name = "Free wifi", Icon = "fas fa-wifi" },
                new { Id = 68, ApartmentId = 16, Name = "Pets allowed", Icon = "fas fa-paw" },
                new { Id = 69, ApartmentId = 16, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new { Id = 70, ApartmentId = 16, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new { Id = 71, ApartmentId = 16, Name = "Family rooms", Icon = "fas fa-users" },
                new { Id = 72, ApartmentId = 16, Name = "Terrace", Icon = "fas fa-umbrella-beach" }
            );
        }
    }
}
