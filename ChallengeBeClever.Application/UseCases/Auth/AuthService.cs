using ChallengeBeClever.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChallengeBeClever.Application.UseCases.Auth
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;


        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<string> Login(string userName, string password)
        {
            if (userName != null && password != null)
            {
                var user = await _userRepository.GetUser(userName, password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
            return null;
        }
    }
}
