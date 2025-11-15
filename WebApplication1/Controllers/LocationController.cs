using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.LocationDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("governorates")]
        public async Task<IActionResult> GetGovernorates()
        {
            try
            {
                var governorates = await _locationService.GetGovernoratesAsync();
                return Ok(governorates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطأ في جلب المحافظات", error = ex.Message });
            }
        }

        [HttpGet("cities/{governorateId}")]
        public async Task<IActionResult> GetCitiesByGovernorate(Guid governorateId)
        {
            try
            {
                var cities = await _locationService.GetCitiesByGovernorateAsync(governorateId);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطأ في جلب المدن", error = ex.Message });
            }
        }
    }
}
