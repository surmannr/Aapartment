using Aapartment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.EntityConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking()
                {
                    Id = 1,
                    StartDate = DateTime.Now.AddDays(4),
                    EndDate = DateTime.Now.AddDays(12),
                    SumPrice = 160300,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 2,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 2,
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(10),
                    SumPrice = 260300,
                    IsPaid = false,
                    NumberOfAdults = 2,
                    NumberOfChildren = 3,
                    RoomId = 5,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 3,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(22),
                    SumPrice = 212330,
                    IsPaid = true,
                    NumberOfAdults = 1,
                    NumberOfChildren = 0,
                    RoomId = 10,
                    UserId = 4
                },
                new Booking()
                {
                    Id = 4,
                    StartDate = DateTime.Now.AddDays(41),
                    EndDate = DateTime.Now.AddDays(62),
                    SumPrice = 53300,
                    IsPaid = true,
                    NumberOfAdults = 2,
                    NumberOfChildren = 4,
                    RoomId = 12,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 5,
                    StartDate = DateTime.Now.AddDays(8),
                    EndDate = DateTime.Now.AddDays(23),
                    SumPrice = 100600,
                    IsPaid = false,
                    NumberOfAdults = 2,
                    NumberOfChildren = 3,
                    RoomId = 25,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 6,
                    StartDate = DateTime.Now.AddDays(4),
                    EndDate = DateTime.Now.AddDays(41),
                    SumPrice = 51111,
                    IsPaid = true,
                    NumberOfAdults = 2,
                    NumberOfChildren = 2,
                    RoomId = 14,
                    UserId = 4
                },
                new Booking()
                {
                    Id = 7,
                    StartDate = DateTime.Now.AddDays(14),
                    EndDate = DateTime.Now.AddDays(32),
                    SumPrice = 600300,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 21,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 8,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(19),
                    SumPrice = 421300,
                    IsPaid = false,
                    NumberOfAdults = 2,
                    NumberOfChildren = 3,
                    RoomId = 17,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 9,
                    StartDate = DateTime.Now.AddDays(112),
                    EndDate = DateTime.Now.AddDays(122),
                    SumPrice = 562300,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 16,
                    UserId = 4
                },
                new Booking()
                {
                    Id = 10,
                    StartDate = DateTime.Now.AddDays(41),
                    EndDate = DateTime.Now.AddDays(78),
                    SumPrice = 960342,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 23,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 11,
                    StartDate = DateTime.Now.AddDays(51),
                    EndDate = DateTime.Now.AddDays(52),
                    SumPrice = 6360,
                    IsPaid = false,
                    NumberOfAdults = 1,
                    NumberOfChildren = 0,
                    RoomId = 13,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 12,
                    StartDate = DateTime.Now.AddDays(65),
                    EndDate = DateTime.Now.AddDays(72),
                    SumPrice = 95530,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 1,
                    RoomId = 10,
                    UserId = 4
                },
                new Booking()
                {
                    Id = 13,
                    StartDate = DateTime.Now.AddDays(8),
                    EndDate = DateTime.Now.AddDays(18),
                    SumPrice = 415300,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 17,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 14,
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(30),
                    SumPrice = 333440,
                    IsPaid = false,
                    NumberOfAdults = 2,
                    NumberOfChildren = 2,
                    RoomId = 5,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 15,
                    StartDate = DateTime.Now.AddDays(51),
                    EndDate = DateTime.Now.AddDays(66),
                    SumPrice = 73031,
                    IsPaid = true,
                    NumberOfAdults = 4,
                    NumberOfChildren = 2,
                    RoomId = 14,
                    UserId = 4
                },
                new Booking()
                {
                    Id = 16,
                    StartDate = DateTime.Now.AddDays(6),
                    EndDate = DateTime.Now.AddDays(41),
                    SumPrice = 976230,
                    IsPaid = true,
                    NumberOfAdults = 3,
                    NumberOfChildren = 2,
                    RoomId = 21,
                    UserId = 2
                },
                new Booking()
                {
                    Id = 17,
                    StartDate = DateTime.Now.AddDays(45),
                    EndDate = DateTime.Now.AddDays(55),
                    SumPrice = 52660,
                    IsPaid = false,
                    NumberOfAdults = 2,
                    NumberOfChildren = 2,
                    RoomId = 8,
                    UserId = 3
                },
                new Booking()
                {
                    Id = 18,
                    StartDate = DateTime.Now.AddDays(63),
                    EndDate = DateTime.Now.AddDays(67),
                    SumPrice = 63960,
                    IsPaid = true,
                    NumberOfAdults = 2,
                    NumberOfChildren = 0,
                    RoomId = 10,
                    UserId = 4
                }
            );
        }
    }
}
