using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AddressDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddressDTO> CreateAddressAsync(CreateAddressDTO createAddressDTO)
        {
            var address = _mapper.Map<Address>(createAddressDTO);
            address.Id = Guid.NewGuid();
            address.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<Address>().AddAsync(address);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO?> GetAddressByIdAsync(Guid id)
        {
            var address = await _unitOfWork.Repository<Address>().GetByIdAsync(id);
            return address != null ? _mapper.Map<AddressDTO>(address) : null;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _unitOfWork.Repository<Address>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public async Task<AddressDTO?> UpdateAddressAsync(UpdateAddressDTO updateAddressDTO)
        {
            var address = await _unitOfWork.Repository<Address>().GetByIdAsync(updateAddressDTO.Id);
            if (address == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateAddressDTO.Street))
                address.Street = updateAddressDTO.Street;
            if (updateAddressDTO.CityId.HasValue)
                address.CityId = updateAddressDTO.CityId.Value;
            if (updateAddressDTO.GovernorateId.HasValue)
                address.GovernorateId = updateAddressDTO.GovernorateId.Value;
            if (!string.IsNullOrWhiteSpace(updateAddressDTO.ZipCode))
                address.ZipCode = updateAddressDTO.ZipCode;
            if (!string.IsNullOrWhiteSpace(updateAddressDTO.Country))
                address.Country = updateAddressDTO.Country;

            await _unitOfWork.Repository<Address>().Update(address);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<bool> DeleteAddressAsync(Guid id)
        {
            var address = await _unitOfWork.Repository<Address>().GetByIdAsync(id);
            if (address == null)
                return false;

            await _unitOfWork.Repository<Address>().Delete(address);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}





