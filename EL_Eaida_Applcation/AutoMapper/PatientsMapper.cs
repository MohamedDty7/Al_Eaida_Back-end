using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class PatientsMapper : Profile
    {
        public PatientsMapper() 
        {
            Console.WriteLine("PatientsMapper Profile is being initialized...");
        
            CreateMap<CreatePatientDTO, Patient>()
                .ForMember(dto => dto.Id, opt => opt.Ignore()) 
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dto => dto.Address, opt => opt.Ignore())
                .ForMember(dto => dto.EmergencyContact, opt => opt.Ignore())
                .ForMember(dto => dto.InsuranceInfo, opt => opt.Ignore())
                .ForMember(dto => dto.MedicalVisits, opt => opt.Ignore()) 
                .ForMember(dto => dto.MedicalHistory, opt => opt.Ignore())
                .ForMember(dto => dto.Appointments, opt => opt.Ignore())
                .ForMember(dto => dto.Invoices, opt => opt.Ignore())
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore())
                .ForMember(dto => dto.UpdatedAt, opt => opt.Ignore())
                .ReverseMap();
                
            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth)))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.CreatedAt)))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.UpdatedAt)))
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.EmergencyContact, opt => opt.Ignore());
                
            CreateMap<PatientDTO, Patient>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.EmergencyContact, opt => opt.Ignore())
                .ForMember(dest => dest.InsuranceInfo, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalVisits, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalHistory, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.Invoices, opt => opt.Ignore());
            
            
            CreateMap<UpdatePatientDTO, Patient>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.HasValue ? src.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null))
                .ForMember(dto => dto.Address, opt => opt.Ignore())
                .ForMember(dto => dto.EmergencyContact, opt => opt.Ignore())
                .ForMember(dto => dto.InsuranceInfo, opt => opt.Ignore())
                .ForMember(dto => dto.MedicalVisits, opt => opt.Ignore()) 
                .ForMember(dto => dto.MedicalHistory, opt => opt.Ignore())
                .ForMember(dto => dto.Appointments, opt => opt.Ignore())
                .ForMember(dto => dto.Invoices, opt => opt.Ignore())
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore())
                .ForMember(dto => dto.UpdatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            Console.WriteLine("PatientsMapper Profile initialization completed successfully!");
        }
    }
}
