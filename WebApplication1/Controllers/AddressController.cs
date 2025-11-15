using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.AddressDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDTO createAddressDTO)
        {
            try
            {
                var address = await _addressServices.CreateAddressAsync(createAddressDTO);
                return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء العنوان: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var address = await _addressServices.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound("العنوان غير موجود");
            }
            return Ok(address);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _addressServices.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressDTO updateAddressDTO)
        {
            try
            {
                var address = await _addressServices.UpdateAddressAsync(updateAddressDTO);
                if (address == null)
                {
                    return NotFound("العنوان غير موجود");
                }
                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث العنوان: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var result = await _addressServices.DeleteAddressAsync(id);
            if (!result)
            {
                return NotFound("العنوان غير موجود");
            }
            return Ok("تم حذف العنوان بنجاح");
        }
    }
}
























