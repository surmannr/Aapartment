using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal
{
    public partial class AapartmentDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }

        public AapartmentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AapartmentDbContext()
        {
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ImageName)
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000);

                entity.HasMany(e => e.Reviews)
                    .WithOne()
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Apartments_Reviews");

                entity.OwnsOne(e => e.Address);

                entity.HasMany(e => e.Rooms)
                    .WithOne()
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Apartments_Rooms");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.StartDate)
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();

                entity.Property(e => e.SumPrice)
                    .IsRequired();

                entity.Property(e => e.NumberOfAdults)
                    .IsRequired();

                entity.Property(e => e.NumberOfChildren)
                    .IsRequired();

                entity.Property(e => e.IsPaid)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Bookings)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Users");

                entity.HasOne(e => e.Room)
                    .WithMany(e => e.Bookings)
                    .HasForeignKey(e => e.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Rooms");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Stars)
                    .IsRequired();

                entity.Property(e => e.Created)
                   .IsRequired();

                entity.Property(e => e.Content)
                    .HasMaxLength(300);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Reviews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Users");

                entity.HasOne(e => e.Apartment)
                    .WithMany(e => e.Reviews)
                    .HasForeignKey(e => e.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Apartments");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomNumber)
                    .IsRequired();

                entity.Property(e => e.PricePerAdult)
                    .IsRequired();

                entity.Property(e => e.PricePerAdult)
                    .IsRequired();

                entity.Property(e => e.MaxNumberOfPeople)
                    .IsRequired();

                entity.Property(e => e.IsAvailabe)
                    .IsRequired();

                entity.HasOne(e => e.Apartment)
                    .WithMany(e => e.Rooms)
                    .HasForeignKey(e => e.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Apartments");

                entity.HasMany(e => e.Bookings)
                    .WithOne(e => e.Room)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Bookings");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

                entity.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

                entity.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

                entity.HasMany(e => e.Bookings)
                    .WithOne()
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Users_Bookings");

                entity.HasMany(e => e.Reviews)
                    .WithOne()
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Users_Reviews");
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
    