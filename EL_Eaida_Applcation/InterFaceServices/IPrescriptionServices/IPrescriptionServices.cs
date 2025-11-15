using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescription;

namespace EL_Eaida_Applcation.InterFaceServices.IPrescriptionServices
{
    public interface IPrescriptionServices 
    {
        Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto dto);
        Task<PrescriptionDto?> GetPrescriptionByIdAsync(Guid id);
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(int pageSize, int pageNumber);
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(Guid patientId);
        Task<PrescriptionDto?> UpdatePrescriptionAsync(UpdatePrescriptionDto dto);
        Task<bool> DeletePrescriptionAsync(Guid id);
    }
}
