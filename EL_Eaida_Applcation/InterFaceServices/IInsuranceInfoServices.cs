using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InsuranceInfoDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IInsuranceInfoServices
    {
        Task<InsuranceInfoDTO> CreateInsuranceInfoAsync(CreateInsuranceInfoDTO createInsuranceInfoDTO);
        Task<InsuranceInfoDTO?> GetInsuranceInfoByIdAsync(Guid id);
        Task<IEnumerable<InsuranceInfoDTO>> GetAllInsuranceInfosAsync();
        Task<InsuranceInfoDTO?> UpdateInsuranceInfoAsync(UpdateInsuranceInfoDTO updateInsuranceInfoDTO);
        Task<bool> DeleteInsuranceInfoAsync(Guid id);
    }
}
























