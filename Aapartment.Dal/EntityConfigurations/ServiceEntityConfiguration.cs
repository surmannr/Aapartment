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
                new { Id = 18, ApartmentId = 3, Name = "Terrace", Icon = "fas fa-umbrella-beach" }
            );
        }
    }
}
