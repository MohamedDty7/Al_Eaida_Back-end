using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicineDTO;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public  class MedicineMapper : Profile
    {
        public MedicineMapper()
        {
            CreateMap<Medicine, MedicineDTO>();
            
            CreateMap<CreateMedicineDTO, Medicine>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Prescriptions, opt => opt.Ignore())
                .ForMember(dest => dest.PrescriptionItems, opt => opt.Ignore())
                .ForMember(dest => dest.MedicationCategories, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateMedicineDTO, Medicine>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Prescriptions, opt => opt.Ignore())
                .ForMember(dest => dest.PrescriptionItems, opt => opt.Ignore())
                .ForMember(dest => dest.MedicationCategories, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
  
}
