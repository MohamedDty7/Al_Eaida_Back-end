using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AddressDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<Address, AddressDTO>();
            
            CreateMap<CreateAddressDTO, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
                
            CreateMap<UpdateAddressDTO, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
























