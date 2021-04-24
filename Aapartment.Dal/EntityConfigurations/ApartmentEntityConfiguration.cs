using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    class ApartmentEntityConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasData( 
                new Apartment() {
                    Id = 1,
                    Description = "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.",
                    Name = "Panama Hotel",
                    ImageName = Guid.NewGuid().ToString(),
                },
                new Apartment()
                {
                    Id = 2,
                    Description = "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.",
                    Name = "Mercur Hotel",
                    ImageName = Guid.NewGuid().ToString(),
                },
                new Apartment()
                {
                    Id = 3,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Langmoon Hotel",
                    ImageName = Guid.NewGuid().ToString(),
                }
            );

            builder.OwnsOne(e => e.Address).HasData(
                new Address()
                {
                    ApartmentId = 3,
                    City = "Peking",
                    Street = "Chicaego street 45",
                    ZipCode = 11004,
                    Country = "China"
                },
                new Address()
                {
                    ApartmentId = 2,
                    City = "Madrid",
                    Street = "Bueno street 45",
                    ZipCode = 3424,
                    Country = "Spain"
                },
                new Address()
                {
                    ApartmentId = 1,
                    City = "New York",
                    Street = "Pearl street 72",
                    ZipCode = 5504,
                    Country = "USA"
                }
            );
        }
    }
}
