using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.InsuranceInfoDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class InsuranceInfoMapper : Profile
    {
        public InsuranceInfoMapper()
        {
            CreateMap<InsuranceInfo, InsuranceInfoDTO>();
            
            CreateMap<CreateInsuranceInfoDTO, InsuranceInfo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateInsuranceInfoDTO, InsuranceInfo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
























