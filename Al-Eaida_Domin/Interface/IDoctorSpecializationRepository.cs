using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IDoctorSpecializationRepository : IGenericRepositery<DoctorSpecialization>
    {
        Task<IEnumerable<DoctorSpecialization>> GetSpecializationsByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<DoctorSpecialization>> GetDoctorsBySpecializationIdAsync(Guid specializationId);
        Task<bool> DoctorHasSpecializationAsync(Guid doctorId, Guid specializationId);
    }
}
