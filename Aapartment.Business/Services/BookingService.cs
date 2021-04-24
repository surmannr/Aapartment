using Aapartment.Business.Dto;
using Aapartment.Business.Exceptions;
using Aapartment.Business.Config;
using Aapartment.Dal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Aapartment.Dal.Entities;
using Aapartment.Business.ServiceInterfaces;

namespace Aapartment.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;

        public BookingService(AapartmentDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<BookingDto> GetByIdAsync(int id)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null) throw new DbNullException();
            return mapper.Map<BookingDto>(booking);
        }

        public async Task<IEnumerable<BookingDto>> GetAllPagedByUserIdAsync(int userid,int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var bookings = await db.Bookings.Where(b => b.UserId == userid).OrderBy(a => a.StartDate).Paging(pagesize, pagenumber).ToListAsync();
            return mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var bookings = await db.Bookings.OrderBy(a => a.StartDate).Paging(pagesize, pagenumber).ToListAsync();
            return mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            if (CheckIfValid(bookingDto))
            {
                var room = await db.Rooms.Where(e => e.Id == bookingDto.RoomId).FirstOrDefaultAsync();
                if (room == null) throw new QueryParamsNullException("Nem létezik a foglaláshoz tartozó szoba");
                if (!room.IsAvailabe) throw new QueryParamsNullException("A szoba foglalt, ezért nem lehet foglalást létrehozni.");

                var user = await db.Users.Where(e => e.Id == bookingDto.UserId).FirstOrDefaultAsync();
                if (user == null) throw new QueryParamsNullException("Nem létezik a foglaláshoz tartozó felhasználó");

                int peopleCount = bookingDto.NumberOfAdults + bookingDto.NumberOfChildren;
                if(peopleCount > room.MaxNumberOfPeople) throw new QueryParamsNullException("Nem fér el ennyi ember a szobában.");

                bookingDto.SumPrice = bookingDto.NumberOfChildren * room.PricePerChild + bookingDto.NumberOfAdults * room.PricePerAdult;

                var booking = mapper.Map<Booking>(bookingDto);
                var result = db.Bookings.Add(booking);
                await db.SaveChangesAsync();
                return mapper.Map<BookingDto>(result.Entity);
                
            }
            else throw new QueryParamsNullException();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null) throw new DbNullException();
            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
        }

        public async Task<BookingDto> ModifyStatusAsync(int id,bool paid)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null) throw new DbNullException();
            booking.IsPaid = paid;
            await db.SaveChangesAsync();
            return mapper.Map<BookingDto>(booking);
        }

        public bool CheckIfValid(BookingDto booking)
        {
            if (booking.StartDate <= DateTime.Now) return false;
            if (booking.EndDate <= booking.StartDate) return false;
            if (booking.RoomId < 0) return false;
            if (booking.UserId < 0) return false;
            if (booking.NumberOfAdults <= 0) return false;
            if (booking.NumberOfChildren <= 0) return false;
            return true;
        }
    }
}
