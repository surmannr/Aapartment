using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class ServiceEntityConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service() {Id=1, ApartmentId = 1, Name = "Free wifi", Icon = "fas fa-wifi" },
                new Service() { Id = 2, ApartmentId = 1, Name = "Pets allowed", Icon = "fas fa-paw" },
                new Service() { Id = 3, ApartmentId = 1, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new Service() { Id = 4, ApartmentId = 1, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new Service() { Id = 5, ApartmentId = 1, Name = "Family rooms", Icon = "fas fa-users" },
                new Service() { Id = 6, ApartmentId = 1, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new Service() { Id = 7, ApartmentId = 2, Name = "Free wifi", Icon = "fas fa-wifi" },
                new Service() { Id = 8, ApartmentId = 2, Name = "Pets allowed", Icon = "fas fa-paw" },
                new Service() { Id = 9, ApartmentId = 2, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new Service() { Id = 10, ApartmentId = 2, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new Service() { Id = 11, ApartmentId = 2, Name = "Family rooms", Icon = "fas fa-users" },
                new Service() { Id = 12, ApartmentId = 2, Name = "Terrace", Icon = "fas fa-umbrella-beach" },
                new Service() { Id = 13, ApartmentId = 3, Name = "Free wifi", Icon = "fas fa-wifi" },
                new Service() { Id = 14, ApartmentId = 3, Name = "Pets allowed", Icon = "fas fa-paw" },
                new Service() { Id = 15, ApartmentId = 3, Name = "Airport shuttle", Icon = "fas fa-shuttle-van" },
                new Service() { Id = 16, ApartmentId = 3, Name = "Non-smoking rooms", Icon = "fas fa-smoking-ban" },
                new Service() { Id = 17, ApartmentId = 3, Name = "Family rooms", Icon = "fas fa-users" },
                new Service() { Id = 18, ApartmentId = 3, Name = "Terrace", Icon = "fas fa-umbrella-beach" }
            );
        }
    }
}
