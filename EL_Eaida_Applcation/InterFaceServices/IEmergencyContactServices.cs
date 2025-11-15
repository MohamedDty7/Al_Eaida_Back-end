using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.EmergencyContactDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IEmergencyContactServices
    {
        Task<EmergencyContactDTO> CreateEmergencyContactAsync(CreateEmergencyContactDTO createEmergencyContactDTO);
        Task<EmergencyContactDTO?> GetEmergencyContactByIdAsync(Guid id);
        Task<IEnumerable<EmergencyContactDTO>> GetAllEmergencyContactsAsync();
        Task<EmergencyContactDTO?> UpdateEmergencyContactAsync(UpdateEmergencyContactDTO updateEmergencyContactDTO);
        Task<bool> DeleteEmergencyContactAsync(Guid id);
    }
}
























