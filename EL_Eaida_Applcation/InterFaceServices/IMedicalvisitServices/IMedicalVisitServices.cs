using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.MedicalVisitDTO;

namespace EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices
{
    public  interface IMedicalVisitServices
    {
        Task<IEnumerable<MedicalVisitDto>> GetAllMedicalVisitsAsync(int pagesize, int pagenumber);
        Task<MedicalVisitDto> GetMedicalVisitByIdAsync(Guid id);
        Task CreateMedicalVisitAsync(CreateMedicalVisitDto createMedicalVisitDto);
        Task<MedicalVisitDto?> UpdateMedicalVisitAsync(UpdateMedicalVisitDto updateMedicalVisitDto);
        Task<bool> DeleteMedicalVisitAsync(Guid id);
        Task<List<MedicalVisitDto>> GetMedicalVisitsByPatientIdAsync(Guid patientId);
    }
}
