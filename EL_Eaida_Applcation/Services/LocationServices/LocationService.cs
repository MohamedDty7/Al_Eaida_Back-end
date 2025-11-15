using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using EL_Eaida_Applcation.DTO.LocationDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.EntityFrameworkCore;

namespace EL_Eaida_Applcation.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GovernorateDTO>> GetGovernoratesAsync()
        {
            var governorates = await _unitOfWork.Repository<Governorate>().GetAllAsync(1, 1000);
            
            return governorates.Select(g => new GovernorateDTO
            {
                Id = g.Id,
                NameAr = g.NameAr,
                NameEn = g.NameEn
            });
        }

        public async Task<IEnumerable<CityDTO>> GetCitiesByGovernorateAsync(Guid governorateId)
        {
            var query = _unitOfWork.Repository<City>().GetQueryable();
            var cities = await query
                .Where(c => c.GovernorateId == governorateId)
                .ToListAsync();
            
            return cities.Select(c => new CityDTO
            {
                Id = c.Id,
                GovernorateId = c.GovernorateId,
                NameAr = c.NameAr,
                NameEn = c.NameEn
            });
        }
    }
}
