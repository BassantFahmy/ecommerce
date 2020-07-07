using AutoMapper;
using ecommerce.Dtos;
using ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.Age,opt=>opt.MapFrom(src => src.DateOfBirth.CalculatAge()));
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
