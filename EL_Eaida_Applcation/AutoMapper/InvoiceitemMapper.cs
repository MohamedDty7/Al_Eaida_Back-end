using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    internal class InvoiceitemMapper : Profile
    {
        public InvoiceitemMapper()
        {
            CreateMap<InvoiceItem, InvoiceItemDto>();
            
            CreateMap<CreateInvoiceItemDto, InvoiceItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateInvoiceItemDto, InvoiceItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        }
    }
}
