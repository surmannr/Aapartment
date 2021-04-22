using Aapartment.Business.Dto;
using Aapartment.Dal.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Config
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
