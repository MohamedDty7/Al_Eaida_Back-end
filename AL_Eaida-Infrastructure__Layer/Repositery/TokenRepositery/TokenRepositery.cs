using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Al_Eaida_Domin.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AL_Eaida_Infrastructure__Layer.Repositery.TokenRepositery
{
    public class TokenRepositery : ITokenRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        private readonly Dictionary<string, string> _refreshTokens = new();


        public TokenRepositery(UserManager<User> userManager, IConfiguration configuration, IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return await Task.FromResult(Convert.ToBase64String(randomBytes));
        }

        public async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? string.Empty),
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials: creds
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                ValidateLifetime = false,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public async Task SaveRefreshTokenAsync(string userId, string refreshToken)
        {
            _refreshTokens[userId] = refreshToken;
            await Task.CompletedTask;
        }

        public async Task<bool> ValidateRefreshTokenAsync(string userId, string refreshToken)
        {
            return await Task.FromResult(_refreshTokens.TryGetValue(userId, out var storedToken) && storedToken == refreshToken);

        }

        private JwtSecurityToken CreateToken(User user, IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials: creds
            );
        }
    }
      
}
