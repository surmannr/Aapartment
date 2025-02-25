﻿using Aapartment.Business.Dto;
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
using Aapartment.Business.Logger;

namespace Aapartment.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public BookingService(AapartmentDbContext _db, IMapper _mapper, ILoggerManager logger)
        {
            db = _db;
            mapper = _mapper;
            this.logger = logger;
        }

        public async Task<BookingDto> GetByIdAsync(int id)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null) {
                logger.LogError($"Error: booking with id:{id} does not exist.");
                throw new DbNullException();
            }
            
            var bookingdto = mapper.Map<BookingDto>(booking);

            var room = await db.Rooms.Where(c => c.Id == bookingdto.RoomId).Include(a => a.Apartment).FirstOrDefaultAsync();
            if (room != null)
            {
                bookingdto.ApartmentName = room.Apartment.Name;
                bookingdto.RoomNumber = room.RoomNumber;
                bookingdto.ApartmentImageName = room.Apartment.ImageName;
            }
            return mapper.Map<BookingDto>(bookingdto);
        }

        public async Task<PagedResult<BookingDto>> GetAllPagedByUserIdAsync(int userid,int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            }

            PagedResult<BookingDto> bookingsresult = new PagedResult<BookingDto>();
            var bookings = await db.Bookings.Where(b => b.UserId == userid).OrderBy(a => a.StartDate).Paging(pagesize, pagenumber).ToListAsync();
            var bookingsForCount = await db.Bookings.Where(b => b.UserId == userid).ToListAsync();

            bookingsresult.AllResultsCount = bookingsForCount.Count();

            var bookingsDto = mapper.Map<List<BookingDto>>(bookings);

            foreach (var b in bookingsDto)
            {
                var room = await db.Rooms.Where(c => c.Id == b.RoomId).Include(a => a.Apartment).FirstOrDefaultAsync();
                if(room != null)
                {
                    b.ApartmentName = room.Apartment.Name;
                    b.RoomNumber = room.RoomNumber;
                    b.ApartmentImageName = room.Apartment.ImageName;
                }
            }

            bookingsresult.PageNumber = pagenumber;
            bookingsresult.PageSize = pagesize;
            bookingsresult.Results = bookingsDto;

            return bookingsresult;
        }

        public async Task<PagedResult<BookingDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            } 
            var bookings = await db.Bookings.OrderBy(a => a.StartDate).Paging(pagesize, pagenumber).ToListAsync();
            var bookingtdos = mapper.Map<List<BookingDto>>(bookings);

            foreach (var b in bookingtdos)
            {
                var room = await db.Rooms.Where(c => c.Id == b.RoomId).Include(a => a.Apartment).FirstOrDefaultAsync();
                if (room != null)
                {
                    b.ApartmentName = room.Apartment.Name;
                    b.RoomNumber = room.RoomNumber;
                    b.ApartmentImageName = room.Apartment.ImageName;
                }
            }

            int count = await db.Bookings.CountAsync();
            PagedResult<BookingDto> result = new PagedResult<BookingDto>();

            result.Results = bookingtdos;
            result.PageSize = pagesize;
            result.PageNumber = pagenumber;
            result.AllResultsCount = count;

            return result;
        }

        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            if (CheckIfValid(bookingDto))
            {
                var room = await db.Rooms.Where(e => e.Id == bookingDto.RoomId).FirstOrDefaultAsync();
                if (room == null)
                {
                    logger.LogError($"Validation failed for creating booking.");
                    throw new QueryParamsNullException("Nem létezik a foglaláshoz tartozó szoba");
                }
                if (!room.IsAvailabe)
                {
                    logger.LogError($"Validation failed for creating apartment.");
                    throw new QueryParamsNullException("A szoba foglalt, ezért nem lehet foglalást létrehozni.");
                }

                var user = await db.Users.Where(e => e.Id == bookingDto.UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    logger.LogError($"Validation failed for creating apartment.");
                    throw new QueryParamsNullException("Nem létezik a foglaláshoz tartozó felhasználó");
                }

                int peopleCount = bookingDto.NumberOfAdults + bookingDto.NumberOfChildren;
                if (peopleCount > room.MaxNumberOfPeople)
                {
                    logger.LogError($"Validation failed for creating apartment.");
                    throw new QueryParamsNullException("Nem fér el ennyi ember a szobában.");
                }

                bookingDto.SumPrice = bookingDto.NumberOfChildren * room.PricePerChild + bookingDto.NumberOfAdults * room.PricePerAdult;

                var booking = mapper.Map<Booking>(bookingDto);
                var result = db.Bookings.Add(booking);
                await db.SaveChangesAsync();
                return mapper.Map<BookingDto>(result.Entity);

            }
            else {
                logger.LogError($"Validation failed for creating apartment.");
                throw new QueryParamsNullException();
            } 
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null) {
                logger.LogError($"Error: booking with id:{id} does not exist.");
                throw new DbNullException();
            }
            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
        }

        public async Task<BookingDto> ModifyStatusAsync(int id,bool paid)
        {
            var booking = await db.Bookings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (booking == null)
            {
                logger.LogError($"Error: booking with id:{id} does not exist.");
                throw new DbNullException();
            }
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
