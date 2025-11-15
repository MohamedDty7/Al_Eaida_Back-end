using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IReceptionistRepository : IGenericRepositery<Receptionist>
    {
        Task<Receptionist?> GetByUserIdAsync(string userId);
        Task<IEnumerable<Receptionist>> GetByDepartmentAsync(string department);
        Task<IEnumerable<Receptionist>> GetActiveReceptionistsAsync();
    }
}
