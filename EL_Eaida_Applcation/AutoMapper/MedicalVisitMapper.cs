using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicalVisitDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class MedicalVisitMapper : Profile
    {
        public MedicalVisitMapper()
        {
            CreateMap<MedicalVisit, MedicalVisitDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.DoctorID, opt => opt.MapFrom(src => src.DoctorID));
                
            CreateMap<CreateMedicalVisitDto, MedicalVisit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Prescriptions, opt => opt.Ignore());
                
            CreateMap<UpdateMedicalVisitDto, MedicalVisit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Prescriptions, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
