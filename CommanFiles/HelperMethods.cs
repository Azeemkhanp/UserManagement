using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Models.ResponseModel;

namespace UserManagement.CommanFiles
{
    public class HelperMethods
    {
        private readonly IConfiguration _configuration;

        public HelperMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateToken(UserResponseModel userResponseModel)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userResponseModel.UserModel.UserName),
                new Claim(ClaimTypes.Email, userResponseModel.UserModel.Email),
                new Claim(ClaimTypes.Role, userResponseModel.UserModel.Role),        // fixed
                new Claim(ClaimTypes.GivenName, userResponseModel.UserModel.FirstName), // fixed
                new Claim(ClaimTypes.Surname, userResponseModel.UserModel.LastName)     // fixed
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Use UtcNow, not Now
                signingCredentials: credentials
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}