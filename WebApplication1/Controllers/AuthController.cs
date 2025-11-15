using EL_Eaida_Applcation.DTO.TokenDTO;
using EL_Eaida_Applcation.DTO.UserDTo;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using EL_Eaida_Applcation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAccountService _acountservices;
        public AuthController(IAccountService acountservices)
        {
            _acountservices = acountservices;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto dto)
        {
            var result = await _acountservices.RegisterAsync(dto);
            return Ok(result);
        }
        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _acountservices.GetAllUsersAsync();
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetbyIdAsync(string id)
        {
            var result = await _acountservices.GestbyIdAsync(id);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        
        {
            try
            {
                var result = await _acountservices.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequestDto dto)
        {
            try
            {
                var result = await _acountservices.RefreshTokenAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // New endpoints for role and status management
        [HttpGet("users/role/{role}")]
        public async Task<IActionResult> GetUsersByRoleAsync(string role)
        {
            try
            {
                var result = await _acountservices.GetUsersByRoleAsync(role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("users/status/{isActive}")]
        public async Task<IActionResult> GetUsersByStatusAsync(bool isActive)
        {
            try
            {
                var result = await _acountservices.GetUsersByStatusAsync(isActive);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("users/role/{role}/status/{isActive}")]
        public async Task<IActionResult> GetUsersByRoleAndStatusAsync(string role, bool isActive)
        {
            try
            {
                var result = await _acountservices.GetUsersByRoleAndStatusAsync(role, isActive);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("users/{userId}/toggle-status")]
        public async Task<IActionResult> ToggleUserStatusAsync(string userId)
        {
            try
            {
                var result = await _acountservices.ToggleUserStatusAsync(userId);
                return Ok(new { 
                    message = "تم تحديث حالة المستخدم بنجاح",
                    isActive = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("users/{userId}/set-status")]
        public async Task<IActionResult> SetUserStatusAsync(string userId, [FromBody] SetUserStatusRequest request)
        {
            try
            {
                var result = await _acountservices.SetUserStatusAsync(userId, request.IsActive);
                return Ok(new { 
                    message = "تم تحديث حالة المستخدم بنجاح",
                    isActive = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("users/{userId}/with-roles")]
        public async Task<IActionResult> GetUserWithRolesAsync(string userId)
        {
            try
            {
                var result = await _acountservices.GetUserWithRolesAsync(userId);
                if (result == null)
                {
                    return NotFound(new { message = "المستخدم غير موجود" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("users/with-roles")]
        public async Task<IActionResult> GetAllUsersWithRolesAsync()
        {
            try
            {
                var result = await _acountservices.GetAllUsersWithRolesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // User management endpoints
        [HttpPut("UpDate/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(string userId, [FromBody] UpdateUserDto dto)
        {
            try
            {
                var result = await _acountservices.UpdateUserAsync(userId, dto);
                return Ok(new { 
                    message = "تم تحديث بيانات المستخدم بنجاح",
                    user = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            try
            {
                var result = await _acountservices.DeleteUserAsync(userId);
                return Ok(new { 
                    message = "تم حذف المستخدم بنجاح",
                    success = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("ChangePasseword/{userId}/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(string userId, [FromBody] ChangePasswordDto dto)
        {
            try
            {
                var result = await _acountservices.ChangePasswordAsync(userId, dto);
                return Ok(new { 
                    message = "تم تغيير كلمة المرور بنجاح",
                    success = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    // DTO for setting user status
    public class SetUserStatusRequest
    {
        public bool IsActive { get; set; }
    }
}
