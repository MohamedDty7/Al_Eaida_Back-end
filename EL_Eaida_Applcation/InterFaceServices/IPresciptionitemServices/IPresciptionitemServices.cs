using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices
{
    public interface IPresciptionitemServices
    {
        Task<PrescriptionItemDto> CreatePrescriptionItemAsync(CreatePrescriptionItemDto createPrescriptionItemDto);
        Task<bool> DeletePrescriptionItemAsync(Guid id);
        Task<IEnumerable<PrescriptionItemDto>> GetAllPrescriptionItemsAsync(int pageSize, int pageNumber);
        Task<PrescriptionItemDto> GetPrescriptionItemByIdAsync(Guid id);
        Task<List<PrescriptionItemDto>> GetPrescriptionItemsByMedicineIdAsync(Guid MedicineId);
        Task<bool> UpdatePrescriptionItemAsync(UpdatePrescriptionItemDto updatePrescriptionItemDto);
    }
}
