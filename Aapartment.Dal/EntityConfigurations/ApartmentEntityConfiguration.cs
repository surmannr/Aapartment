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
                    ImageName = "alap1.jpg",
                },
                new Apartment()
                {
                    Id = 2,
                    Description = "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.",
                    Name = "Mercur Hotel",
                    ImageName = "alap2.jpg",
                },
                new Apartment()
                {
                    Id = 3,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Langmoon Hotel",
                    ImageName = "alap3.jpg",
                },
                new Apartment()
                {
                    Id = 4,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Malaha Hotel",
                    ImageName = "alap4.jpg",
                },
                new Apartment()
                {
                    Id = 5,
                    Description = "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.",
                    Name = "Retro Hotel",
                    ImageName = "alap5.jpg",
                },
                new Apartment()
                {
                    Id = 6,
                    Description = "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.",
                    Name = "Sunshine Hotel",
                    ImageName = "alap6.jpg",
                },
                new Apartment()
                {
                    Id = 7,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Happymoon Hotel",
                    ImageName = "alap7.jpg",
                },
                new Apartment()
                {
                    Id = 8,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Aquarell Hotel",
                    ImageName = "alap8.jpg",
                },
                new Apartment()
                {
                    Id = 9,
                    Description = "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.",
                    Name = "Phonin Hotel",
                    ImageName = "alap9.jpg",
                },
                new Apartment()
                {
                    Id = 10,
                    Description = "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.",
                    Name = "Willis Hotel",
                    ImageName = "alap10.jpeg",
                },
                new Apartment()
                {
                    Id = 11,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Pandora Hotel",
                    ImageName = "alap11.jpeg",
                },
                new Apartment()
                {
                    Id = 12,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Nostra Hotel",
                    ImageName = "alap12.jpg",
                },
                new Apartment()
                {
                    Id = 13,
                    Description = "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.",
                    Name = "Nautis Hotel",
                    ImageName = "alap13.jpg",
                },
                new Apartment()
                {
                    Id = 14,
                    Description = "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.",
                    Name = "Edgbaston Hotel",
                    ImageName = "alap14.jpg",
                },
                new Apartment()
                {
                    Id = 15,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Indigo Hotel",
                    ImageName = "alap15.jpg",
                },
                new Apartment()
                {
                    Id = 16,
                    Description = "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.",
                    Name = "Boulvard Hotel",
                    ImageName = "alap16.jpg",
                }
            );

            builder.OwnsOne(e => e.Address).HasData(
                new Address()
                {
                    ApartmentId = 4,
                    City = "Honolulu",
                    Street = "Upalu St street 3",
                    ZipCode = 96705,
                    Country = "USA"
                },
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
                },
                new Address()
                {
                    ApartmentId = 5,
                    City = "Budapest",
                    Street = "Havanna St street 3",
                    ZipCode = 1181,
                    Country = "Hungary"
                },
                new Address()
                {
                    ApartmentId = 6,
                    City = "Tokyo",
                    Street = "Kaumu street 410",
                    ZipCode = 5620,
                    Country = "Japan"
                },
                new Address()
                {
                    ApartmentId = 7,
                    City = "Delhi",
                    Street = "Temple street 80",
                    ZipCode = 41023,
                    Country = "India"
                },
                new Address()
                {
                    ApartmentId = 8,
                    City = "Shanghai",
                    Street = "Ruraro street 91",
                    ZipCode = 632302,
                    Country = "China"
                },
                new Address()
                {
                    ApartmentId = 9,
                    City = "Sao Paulo",
                    Street = "Peloza street 33",
                    ZipCode = 5231,
                    Country = "Brazil"
                },
                new Address()
                {
                    ApartmentId = 10,
                    City = "Mexico City",
                    Street = "Mehikan street 28",
                    ZipCode = 2468,
                    Country = "Mexico"
                },
                new Address()
                {
                    ApartmentId = 11,
                    City = "Dhaka",
                    Street = "Proauro street 11",
                    ZipCode = 9743,
                    Country = "Bangladesh"
                },
                new Address()
                {
                    ApartmentId = 12,
                    City = "Cairo",
                    Street = "Pyramor street 52",
                    ZipCode = 7531,
                    Country = "Egypt"
                },
                new Address()
                {
                    ApartmentId = 13,
                    City = "Osaka",
                    Street = "Muramura street 3",
                    ZipCode = 8232,
                    Country = "Japan"
                },
                new Address()
                {
                    ApartmentId = 14,
                    City = "Istanbul",
                    Street = "Gyromar street 45",
                    ZipCode = 7821,
                    Country = "Turkey"
                },
                new Address()
                {
                    ApartmentId = 15,
                    City = "Manila",
                    Street = "Kaucor street 85",
                    ZipCode = 36301,
                    Country = "Philippines"
                },
                new Address()
                {
                    ApartmentId = 16,
                    City = "Los Angeles",
                    Street = "Fedora street 74",
                    ZipCode = 74511,
                    Country = "USA"
                }
            );
        }
    }
}
