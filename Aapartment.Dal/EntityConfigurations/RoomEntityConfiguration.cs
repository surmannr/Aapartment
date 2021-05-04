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
                },
                new Room()
                {
                    Id = 21,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 22,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 23,
                    ApartmentId = 5,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 24,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 25,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 26,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 27,
                    ApartmentId = 5,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 28,
                    ApartmentId = 6,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 29,
                    ApartmentId = 6,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 30,
                    ApartmentId = 6,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 31,
                    ApartmentId = 7,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 32,
                    ApartmentId = 7,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 33,
                    ApartmentId = 7,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 34,
                    ApartmentId = 7,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 35,
                    ApartmentId = 8,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 36,
                    ApartmentId = 8,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 37,
                    ApartmentId = 8,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 38,
                    ApartmentId = 8,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 39,
                    ApartmentId = 8,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 40,
                    ApartmentId = 8,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 41,
                    ApartmentId = 9,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 42,
                    ApartmentId = 9,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 43,
                    ApartmentId = 9,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 44,
                    ApartmentId = 10,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 45,
                    ApartmentId = 10,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 46,
                    ApartmentId = 10,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 47,
                    ApartmentId = 10,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 48,
                    ApartmentId = 11,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 49,
                    ApartmentId = 11,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 50,
                    ApartmentId = 11,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 51,
                    ApartmentId = 12,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 52,
                    ApartmentId = 13,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 53,
                    ApartmentId = 13,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 54,
                    ApartmentId = 13,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 55,
                    ApartmentId = 13,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 56,
                    ApartmentId = 14,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 57,
                    ApartmentId = 14,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 58,
                    ApartmentId = 14,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 59,
                    ApartmentId = 14,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 60,
                    ApartmentId = 14,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 61,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 62,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 63,
                    ApartmentId = 15,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 64,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 65,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 66,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 67,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 68,
                    ApartmentId = 15,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 69,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 70,
                    ApartmentId = 15,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 71,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 72,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 73,
                    ApartmentId = 16,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 74,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 75,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5050,
                    PricePerChild = 2700,
                    RoomNumber = 105
                },
                new Room()
                {
                    Id = 76,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 5000,
                    PricePerChild = 2400,
                    RoomNumber = 101
                },
                new Room()
                {
                    Id = 77,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 3,
                    PricePerAdult = 5500,
                    PricePerChild = 2450,
                    RoomNumber = 102
                },
                new Room()
                {
                    Id = 78,
                    ApartmentId = 16,
                    IsAvailabe = false,
                    MaxNumberOfPeople = 7,
                    PricePerAdult = 5400,
                    PricePerChild = 2000,
                    RoomNumber = 103
                },
                new Room()
                {
                    Id = 79,
                    ApartmentId = 16,
                    IsAvailabe = true,
                    MaxNumberOfPeople = 4,
                    PricePerAdult = 6000,
                    PricePerChild = 3400,
                    RoomNumber = 104
                },
                new Room()
                {
                    Id = 80,
                    ApartmentId = 16,
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
