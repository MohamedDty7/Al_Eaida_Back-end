using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.MedicalRecordDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IMedicalRecordServices
    {
        Task<MedicalRecordDTO> CreateMedicalRecordAsync(CreateMedicalRecordDTO createMedicalRecordDTO);
        Task<MedicalRecordDTO?> GetMedicalRecordByIdAsync(Guid id);
        Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecordsAsync();
        Task<MedicalRecordDTO?> UpdateMedicalRecordAsync(UpdateMedicalRecordDTO updateMedicalRecordDTO);
        Task<bool> DeleteMedicalRecordAsync(Guid id);
        Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByPatientIdAsync(Guid patientId);
        Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByDoctorIdAsync(Guid doctorId);
    }
}
