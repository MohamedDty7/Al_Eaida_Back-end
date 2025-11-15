using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.DoctorDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            
            CreateMap<Doctor, DoctorDetailsDTO>()
                .ForMember(dest => dest.Specializations, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.TotalAppointments, opt => opt.Ignore())
                .ForMember(dest => dest.TodayAppointments, opt => opt.Ignore());
            
            CreateMap<CreateDoctorDTO, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalRecords, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalVisits, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorSpecializations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateDoctorDTO, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalRecords, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalVisits, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorSpecializations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}



