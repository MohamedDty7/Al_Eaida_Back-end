using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.DoctorDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IDoctorServices
    {
        Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO createDoctorDTO);
        Task<DoctorDTO?> GetDoctorByIdAsync(string id);
        Task<DoctorDetailsDTO?> GetDoctorDetailsByIdAsync(string id);
        Task<PaginatedDoctorsResponse> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 10);
        Task<DoctorDTO?> UpdateDoctorAsync(UpdateDoctorDTO updateDoctorDTO);
        Task<bool> DeleteDoctorAsync(string id);
        Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecializationAsync(string specialization);
    }
}



