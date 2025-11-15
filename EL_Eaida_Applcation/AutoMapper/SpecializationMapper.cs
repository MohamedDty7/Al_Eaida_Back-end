using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.SpecializationDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class SpecializationMapper : Profile
    {
        public SpecializationMapper()
        {
            CreateMap<Specialization, SpecializationDTO>();
            
            CreateMap<CreateSpecializationDTO, Specialization>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorSpecializations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateSpecializationDTO, Specialization>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorSpecializations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
























