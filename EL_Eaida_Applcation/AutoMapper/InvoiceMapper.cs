using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.IncoiceDTO;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedByUser.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
                
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<InvoiceStatus>(src.Status)));
                
            CreateMap<UpdateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 
                    !string.IsNullOrEmpty(src.Status) ? Enum.Parse<InvoiceStatus>(src.Status) : (InvoiceStatus?)null))
                .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        }
    }

}
