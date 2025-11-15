using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.SpecializationDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface ISpecializationServices
    {
        Task<SpecializationDTO> CreateSpecializationAsync(CreateSpecializationDTO createSpecializationDTO);
        Task<SpecializationDTO?> GetSpecializationByIdAsync(string id);
        Task<IEnumerable<SpecializationDTO>> GetAllSpecializationsAsync();
        Task<SpecializationDTO?> UpdateSpecializationAsync(UpdateSpecializationDTO updateSpecializationDTO);
        Task<bool> DeleteSpecializationAsync(string id);
    }
}
























