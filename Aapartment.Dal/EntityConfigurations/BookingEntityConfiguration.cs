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
                }
            );
        }
    }
}
