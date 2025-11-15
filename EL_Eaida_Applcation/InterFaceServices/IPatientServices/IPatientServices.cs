using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.InterFaceServices.IPatientServices
{
    public interface IPatientService
    {
        // الدوال الأساسية
        Task<PatientDTO?> GetPatientByIdAsync(Guid id);
        Task AddPatientAsync(CreatePatientDTO patient);
        Task<bool> UpdatePatientAsync(UpdatePatientDTO patient);
        Task<bool> DeletePatientAsync(Guid id);

        // دوال عرض المرضى مع الصفحات
        Task<PagedPatientResultDTO> GetAllPatientsPagedAsync(int pageNumber, int pageSize);
        Task<PagedPatientResultDTO> GetPatientsByNamePagedAsync(string name, int pageNumber, int pageSize);
        Task<PagedPatientResultDTO> GetPatientsByGenderPagedAsync(string gender, int pageNumber, int pageSize);
        Task<PagedPatientResultDTO> GetPatientsByStatusPagedAsync(bool isActive, int pageNumber, int pageSize);
        Task<PagedPatientResultDTO> GetPatientsFilteredPagedAsync(string? name, string? gender, bool? isActive, int pageNumber, int pageSize);

        // الدوال القديمة (للتوافق مع الكود الموجود)
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<PatientDTO>> GetPatientFilter(int pageNumber, int pageSize, string? name = null, string? gender = null);
        Task<IEnumerable<PatientDTO>> FilterPatientsAsync(string? name, string? gender);
    }
}
