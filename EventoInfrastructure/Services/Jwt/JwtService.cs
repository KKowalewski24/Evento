using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventoCore.Domain;
using EventoInfrastructure.DTO.Jwt;
using EventoInfrastructure.Extensions;
using EventoInfrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace EventoInfrastructure.Services.Jwt {

    public class JwtService : IJwtService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly JwtSettings _jwtSettings;

        /*------------------------ METHODS REGION ------------------------*/
        public JwtService(JwtSettings jwtSettings) {
            _jwtSettings = jwtSettings;
        }

        public JwtDTO CreateToken(Guid userId, UserRole role) {
            DateTime now = DateTime.UtcNow;
            DateTime expireTime = now.AddMinutes(_jwtSettings.ExpiryTimeInMinutes);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.ApplicationUrl,
                claims: SetupClaims(userId, role, now),
                notBefore: now,
                expires: expireTime,
                signingCredentials: SetupSigningCredentials()
            );

            return new JwtDTO(
                new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), expireTime.ToTimestamp()
            );
        }

        private SigningCredentials SetupSigningCredentials() {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)),
                SecurityAlgorithms.HmacSha256
            );
        }

        private Claim[] SetupClaims(Guid userId, UserRole role, DateTime now) {
            return new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
            };
        }

    }

}
