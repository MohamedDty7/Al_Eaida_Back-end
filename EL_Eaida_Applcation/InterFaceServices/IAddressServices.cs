using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.AddressDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IAddressServices
    {
        Task<AddressDTO> CreateAddressAsync(CreateAddressDTO createAddressDTO);
        Task<AddressDTO?> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO?> UpdateAddressAsync(UpdateAddressDTO updateAddressDTO);
        Task<bool> DeleteAddressAsync(Guid id);
    }
}
























