using EL_Eaida_Applcation.DTO.ReceptionistDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IReceptionistServices
    {
        Task<ReceptionistDTO> CreateReceptionistAsync(CreateReceptionistDTO createDto);
        Task<ReceptionistDTO?> GetReceptionistByIdAsync(Guid id);
        Task<ReceptionistDTO?> GetReceptionistByUserIdAsync(string userId);
        Task<IEnumerable<ReceptionistDTO>> GetAllReceptionistsAsync();
        Task<IEnumerable<ReceptionistDTO>> GetReceptionistsByDepartmentAsync(string department);
        Task<ReceptionistDTO?> UpdateReceptionistAsync(UpdateReceptionistDTO updateDto);
        Task<bool> DeleteReceptionistAsync(Guid id);
    }
}
