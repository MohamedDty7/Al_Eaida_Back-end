using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.TokenDTO;
using EL_Eaida_Applcation.DTO.UserDTo;

namespace EL_Eaida_Applcation.InterFaceServices.IAutherServices
{
    public interface IAccountService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GestbyIdAsync(string id);

        // New methods for role and status management
        Task<IEnumerable<UserDTO>> GetUsersByRoleAsync(string role);
        Task<IEnumerable<UserDTO>> GetUsersByStatusAsync(bool isActive);
        Task<IEnumerable<UserDTO>> GetUsersByRoleAndStatusAsync(string role, bool isActive);
        Task<bool> ToggleUserStatusAsync(string userId);
        Task<bool> SetUserStatusAsync(string userId, bool isActive);
        Task<UserDTO?> GetUserWithRolesAsync(string userId);
        Task<IEnumerable<UserDTO>> GetAllUsersWithRolesAsync();
        
        // User management methods
        Task<UserDTO> UpdateUserAsync(string userId, UpdateUserDto dto);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto dto);
    }
}
