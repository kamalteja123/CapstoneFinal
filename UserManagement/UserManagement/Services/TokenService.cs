using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Interfaces;
using UserManagement.Models.DTO;

namespace UserManagement.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _key;

        public TokenService(IConfiguration configuration)
        {
            _key = Encoding.UTF8.GetBytes(configuration["Keys:TokenKey"] ?? "");//here the keys is the key of the appsetting.json and the value is the tokenkeys
        }
        public async Task<string> GenerateToken(ResponseDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
               
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("UserId", user.UId.ToString())
            };
            var symmetricSecurityKey = new SymmetricSecurityKey(_key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
