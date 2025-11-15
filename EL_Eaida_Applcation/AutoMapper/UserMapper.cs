using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.UserDTo;
using Microsoft.AspNetCore.Identity;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            // User إلى UserDTO
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // تجاهل Role هنا
                .ReverseMap();

            // User إلى UserResponseDto
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLoginAt))
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // تجاهل Role هنا
                .ReverseMap();

            // RegisterRequestDto إلى User
            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastLoginAt, opt => opt.Ignore());

            // IdentityUser إلى LoginDto
            CreateMap<IdentityUser, LoginDto>().ReverseMap();
        }
    }
}
