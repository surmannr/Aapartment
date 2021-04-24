using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room()
                {
                    Id = 1,
                    ApartmentId = 1,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 2,
                    ApartmentId = 1,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 3,
                    ApartmentId = 1,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 4,
                    ApartmentId = 1,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 5,
                    ApartmentId = 1,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 6,
                    ApartmentId = 2,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 7,
                    ApartmentId = 2,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 8,
                    ApartmentId = 2,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 9,
                    ApartmentId = 2,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 10,
                    ApartmentId = 2,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 11,
                    ApartmentId = 3,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 12,
                    ApartmentId = 3,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 13,
                    ApartmentId = 3,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 14,
                    ApartmentId = 3,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 15,
                    ApartmentId = 3,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 16,
                    ApartmentId = 4,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 17,
                    ApartmentId = 4,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 18,
                    ApartmentId = 4,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 19,
                    ApartmentId = 4,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 20,
                    ApartmentId = 4,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                }
            );
        }
    }
}
