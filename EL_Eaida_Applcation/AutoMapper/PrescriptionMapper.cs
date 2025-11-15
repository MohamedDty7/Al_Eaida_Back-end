using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescription;

namespace EL_Eaida_Applcation.AutoMapper
{
    internal class PrescriptionMapper : Profile
    {
        public PrescriptionMapper()
        {
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.MedicationName, opt => opt.MapFrom(src => src.Medication.Name))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.PrescriptionItems));
                
            CreateMap<CreatePrescriptionDto, Prescription>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Medication, opt => opt.Ignore())
                .ForMember(dest => dest.PrescriptionItems, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PrescribedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
                
            CreateMap<UpdatePrescriptionDto, Prescription>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Medication, opt => opt.Ignore())
                .ForMember(dest => dest.PrescriptionItems, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
    
}
