
using System.Data;
using System.Security.Claims;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.TokenDTO;
using EL_Eaida_Applcation.DTO.UserDTo;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using Microsoft.AspNetCore.Identity;

namespace EL_Eaida_Applcation.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public AccountService(
         UserManager<User> userManager,
         ITokenRepository tokenRepository,
         IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GestbyIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }
            
            var userDto = _mapper.Map<UserDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.ToList();
            
            return userDto;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var userDtos = new List<UserDTO>();
            
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.ToList();
                userDtos.Add(userDto);
            }
            
            return userDtos;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            // البحث عن المستخدم بالبريد الإلكتروني أو اسم المستخدم
            var user = await _userManager.FindByEmailAsync(dto.Email) ?? 
                      await _userManager.FindByNameAsync(dto.Email);
                      
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            // التحقق من حالة المستخدم
            if (!user.IsActive)
            {
                throw new Exception("حساب المستخدم غير مفعل");
            }

            // التحقق من كلمة المرور
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new Exception("كلمة المرور غير صحيحة");
            }

            // تحديث آخر تسجيل دخول
            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            // إنشاء التوكن
            var token = await _tokenRepository.GenerateToken(user);
            var refreshToken = await _tokenRepository.GenerateRefreshToken();
            await _tokenRepository.SaveRefreshTokenAsync(user.Id, refreshToken);

            // استخدام AutoMapper لتحويل المستخدم
            var userDto = _mapper.Map<UserDTO>(user);

            // إضافة الأدوار يدوياً (لأن AutoMapper لا يستطيع الحصول عليها)
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.ToList();

            return new AuthResponseDto
            {
                Token = token,
                Refresh = refreshToken,
                User = userDto
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var principal = _tokenRepository.GetPrincipalFromExpiredToken(dto.Token);
            if (principal == null)
            {
                throw new Exception("رمز غير صالح");
            }
            
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new Exception("معرف المستخدم غير موجود في الرمز");
            }
            
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }
            
            if (!user.IsActive)
            {
                throw new Exception("حساب المستخدم غير مفعل");
            }
            
            if (!await _tokenRepository.ValidateRefreshTokenAsync(userId, dto.RefreshToken))
            {
                throw new Exception("رمز التحديث غير صالح");
            }
            
            // تحديث آخر تسجيل دخول
            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            
            var newToken = await _tokenRepository.GenerateToken(user);
            var newRefreshToken = await _tokenRepository.GenerateRefreshToken();
            await _tokenRepository.SaveRefreshTokenAsync(userId, newRefreshToken);
            
            var userDto = _mapper.Map<UserDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.ToList();
            
            return new AuthResponseDto
            {
                Token = newToken,
                Refresh = newRefreshToken,
                User = userDto
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            // Check if email already exists
            var existingUserByEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUserByEmail != null)
            {
                throw new Exception("البريد الإلكتروني مستخدم بالفعل");
            }

            // Check if username already exists
            var existingUserByUsername = await _userManager.FindByNameAsync(dto.Username);
            if (existingUserByUsername != null)
            {
                throw new Exception("اسم المستخدم مستخدم بالفعل");
            }

            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.EmailConfirmed = true; // Auto-confirm email for now
            
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description).ToList();
                var errorMessage = string.Join(", ", errorMessages);
                throw new Exception($"فشل في إنشاء المستخدم: {errorMessage}");
            }

            // Add roles to user
            foreach (var role in dto.Role)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                var roleResult = await _userManager.AddToRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception($"فشل في إضافة الدور '{role}': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                }
            }

            var token = await _tokenRepository.GenerateToken(user);
            var refreshToken = await _tokenRepository.GenerateRefreshToken();
            await _tokenRepository.SaveRefreshTokenAsync(user.Id, refreshToken);

            return new AuthResponseDto
            {
                Token = token,
                Refresh = refreshToken,
                User = _mapper.Map<UserDTO>(user)
            };
        }

        // Get users by role
        public async Task<IEnumerable<UserDTO>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            var userDtos = new List<UserDTO>();
            
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.ToList();
                userDtos.Add(userDto);
            }
            
            return userDtos;
        }

        // Get users by active status
        public async Task<IEnumerable<UserDTO>> GetUsersByStatusAsync(bool isActive)
        {
            var users = _userManager.Users.Where(u => u.IsActive == isActive).ToList();
            var userDtos = new List<UserDTO>();
            
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.ToList();
                userDtos.Add(userDto);
            }
            
            return userDtos;
        }

        // Get users by role and status
        public async Task<IEnumerable<UserDTO>> GetUsersByRoleAndStatusAsync(string role, bool isActive)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(role);
            var filteredUsers = usersInRole.Where(u => u.IsActive == isActive).ToList();
            var userDtos = new List<UserDTO>();
            
            foreach (var user in filteredUsers)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.ToList();
                userDtos.Add(userDto);
            }
            
            return userDtos;
        }

        // Toggle user active status
        public async Task<bool> ToggleUserStatusAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);
            
            if (!result.Succeeded)
            {
                throw new Exception($"فشل في تحديث حالة المستخدم: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            return user.IsActive;
        }

        // Set user active status
        public async Task<bool> SetUserStatusAsync(string userId, bool isActive)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            user.IsActive = isActive;
            var result = await _userManager.UpdateAsync(user);
            
            if (!result.Succeeded)
            {
                throw new Exception($"فشل في تحديث حالة المستخدم: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            return user.IsActive;
        }

        // Get user with roles
        public async Task<UserDTO?> GetUserWithRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.ToList();
            
            return userDto;
        }

        // Get all users with roles (updated version)
        public async Task<IEnumerable<UserDTO>> GetAllUsersWithRolesAsync()
        {
            var users = _userManager.Users.ToList();
            var userDtos = new List<UserDTO>();
            
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.ToList();
                userDtos.Add(userDto);
            }
            
            return userDtos;
        }

        // Update user information
        public async Task<UserDTO> UpdateUserAsync(string userId, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            // Check if email is already taken by another user
            var existingUserByEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUserByEmail != null && existingUserByEmail.Id != userId)
            {
                throw new Exception("البريد الإلكتروني مستخدم بالفعل");
            }

            // Check if username is already taken by another user
            var existingUserByUsername = await _userManager.FindByNameAsync(dto.UserName);
            if (existingUserByUsername != null && existingUserByUsername.Id != userId)
            {
                throw new Exception("اسم المستخدم مستخدم بالفعل");
            }

            // Update user properties
            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.NormalizedUserName = dto.UserName.ToUpper();
            user.NormalizedEmail = dto.Email.ToUpper();
            user.PhoneNumber = dto.Phone ?? string.Empty;
            user.Address = dto.Address ?? string.Empty;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"فشل في تحديث المستخدم: {errors}");
            }

            // Return updated user with roles
            var userDto = _mapper.Map<UserDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.ToList();

            return userDto;
        }

        // Delete user
        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"فشل في حذف المستخدم: {errors}");
            }

            return true;
        }

        // Change user password
        public async Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            // Verify current password
            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, dto.CurrentPassword);
            if (!isCurrentPasswordValid)
            {
                throw new Exception("كلمة المرور الحالية غير صحيحة");
            }

            // Change password
            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"فشل في تغيير كلمة المرور: {errors}");
            }

            return true;
        }
    }
    }
