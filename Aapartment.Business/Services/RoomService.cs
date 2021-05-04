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
using Aapartment.Business.Logger;

namespace Aapartment.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public RoomService(AapartmentDbContext _db, IMapper _mapper, ILoggerManager logger)
        {
            db = _db;
            mapper = _mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<RoomDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            } 
            var rooms = await db.Rooms.OrderBy(a => a.RoomNumber).Paging(pagesize, pagenumber).ToListAsync();
            return mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<int> GetAllCountByApartmentId(int apartmentid)
        {
            var rooms = await db.Rooms.Where(b => b.ApartmentId == apartmentid).OrderBy(a => a.RoomNumber).ToListAsync();
            return rooms.Count();
        }

        public async Task<IEnumerable<RoomDto>> GetAllPagedByApartmentIdAsync(int apartmentid, int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0)
            {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            }
            var rooms = await db.Rooms.Where(b => b.ApartmentId == apartmentid).OrderBy(a => a.RoomNumber).Paging(pagesize, pagenumber).ToListAsync();
            return mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> CreateAsync(RoomDto roomDto)
        {
            if (CheckIfValid(roomDto))
            {
                var apartment = await db.Apartments.Where(e => e.Id == roomDto.ApartmentId).FirstOrDefaultAsync();
                if (apartment == null)
                {
                    logger.LogError($"Validation failed for creating review.");
                    throw new QueryParamsNullException("Nem létezik a szobához tartozó szálloda.");
                }

                var room = mapper.Map<Room>(roomDto);
                var result = db.Rooms.Add(room);
                await db.SaveChangesAsync();
                return mapper.Map<RoomDto>(result.Entity);

            }
            else {
                logger.LogError($"Validation failed for creating room.");
                throw new QueryParamsNullException();
            } 
        }

        public async Task DeleteAsync(int id)
        {
            var room = await db.Rooms.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (room == null) {
                logger.LogError($"Error: room with id:{id} does not exist.");
                throw new DbNullException();
            } 
            db.Rooms.Remove(room);
            await db.SaveChangesAsync();
        }

        public async Task<RoomDto> ModifyAsync(int id, RoomDto roomDto)
        {
            if (CheckIfValid(roomDto))
            {
                var room = await db.Rooms.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (room == null)
                {
                    logger.LogError($"Error: room with id:{id} does not exist.");
                    throw new DbNullException();
                }

                var apartment = await db.Rooms.Where(a => a.Id == room.ApartmentId).FirstOrDefaultAsync();
                if (apartment == null)
                {
                    logger.LogError($"Error: apartment with id:{room.ApartmentId} does not exist.");
                    throw new DbNullException();
                }

                room.IsAvailabe = roomDto.IsAvailabe;
                room.MaxNumberOfPeople = roomDto.MaxNumberOfPeople;
                room.PricePerAdult = roomDto.PricePerAdult;
                room.PricePerChild = roomDto.PricePerChild;
                room.RoomNumber = roomDto.RoomNumber;

                await db.SaveChangesAsync();
                return mapper.Map<RoomDto>(room);
            }
            else
            {
                logger.LogError($"Validation failed for creating room.");
                throw new QueryParamsNullException();
            }
        }

        public async Task<RoomDto> ModifyAvailableAsync(int id, bool available)
        {
            var room = await db.Rooms.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (room == null)
            {
                logger.LogError($"Error: room with id:{id} does not exist.");
                throw new DbNullException();
            }

            room.IsAvailabe = available;

            await db.SaveChangesAsync();
            return mapper.Map<RoomDto>(room);
        }

        public bool CheckIfValid(RoomDto room)
        {
            if (room.RoomNumber <= 0) return false;
            if (room.PricePerChild < 0) return false;
            if (room.PricePerAdult < 0) return false;
            if (room.MaxNumberOfPeople <= 0) return false;
            if (room.ApartmentId <= 0) return false;
            return true;
        }

        public async Task<IEnumerable<RoomDto>> GetAllByApartmentIdAsync(int apartmentid)
        {
            var rooms = await db.Rooms.Where(b => b.ApartmentId == apartmentid).OrderBy(a => a.RoomNumber).ToListAsync();
            return mapper.Map<List<RoomDto>>(rooms);
        }
    }
}
