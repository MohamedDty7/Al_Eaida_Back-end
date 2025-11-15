using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class PrescriptionitemMapper : Profile
    {
        public PrescriptionitemMapper()
        {
            CreateMap<PrescriptionItem, PrescriptionItemDto>()
                .ForMember(dest => dest.MedicationName, opt => opt.MapFrom(src => src.Medicine.Name));
                
            CreateMap<CreatePrescriptionItemDto, PrescriptionItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Prescription, opt => opt.Ignore())
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
                
            CreateMap<UpdatePrescriptionItemDto, PrescriptionItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Prescription, opt => opt.Ignore())
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}