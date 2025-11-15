using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AppointmentDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.PatientPhone, opt => opt.MapFrom(src => src.Patient.Phone))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.AppointmentDate))
                .ReverseMap();
                
            CreateMap<CreateAppointmentDto, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ParseAppointmentStatus(src.Status)));
                
            CreateMap<UpdateAppointmentDto, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => 
                    src.AppointmentDate.HasValue ? src.AppointmentDate.Value.Date + TimeSpan.Parse(src.Time ?? "00:00") : DateTime.Now))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        
        private static AppointmentStatus ParseAppointmentStatus(string status)
        {
            return status switch
            {
                "مؤكد" => AppointmentStatus.مؤكد,
                "في_الانتظار" or "في الانتظار" => AppointmentStatus.في_الانتظار,
                "جاري_الفحص" or "جاري الفحص" => AppointmentStatus.جاري_الفحص,
                "مكتمل" => AppointmentStatus.مكتمل,
                "تأجيل" => AppointmentStatus.تأجيل,
                "ملغي" => AppointmentStatus.ملغي,
                _ => AppointmentStatus.في_الانتظار
            };
        }
    }
}
