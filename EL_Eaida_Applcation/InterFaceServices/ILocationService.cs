using EL_Eaida_Applcation.DTO.LocationDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface ILocationService
    {
        Task<IEnumerable<GovernorateDTO>> GetGovernoratesAsync();
        Task<IEnumerable<CityDTO>> GetCitiesByGovernorateAsync(Guid governorateId);
    }
}



















