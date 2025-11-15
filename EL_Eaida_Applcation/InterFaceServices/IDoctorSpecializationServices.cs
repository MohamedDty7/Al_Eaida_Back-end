using EL_Eaida_Applcation.DTO.DoctorSpecializationDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IDoctorSpecializationServices
    {
        Task<DoctorSpecializationDTO> CreateSpecializationAsync(CreateDoctorSpecializationDTO createDto);
        Task<DoctorSpecializationDTO?> GetSpecializationByIdAsync(Guid id);
        Task<IEnumerable<DoctorSpecializationDTO>> GetAllSpecializationsAsync();
        Task<IEnumerable<DoctorSpecializationDTO>> GetSpecializationsByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<DoctorSpecializationDTO>> GetDoctorsBySpecializationIdAsync(Guid specializationId);
        Task<bool> DeleteSpecializationAsync(Guid id);
    }
}
