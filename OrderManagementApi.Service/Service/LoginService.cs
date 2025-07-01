using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagementApi.DTO.Login.Request;
using OrderManagementApi.DTO.User.Request;
using OrderManagementApi.DTO.User.Response;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderManagementApi.Service.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public LoginService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();

            UserGetRequest userGetRequest = new UserGetRequest
            {
                Username = loginRequest.Username,
                Password = loginRequest.Password
            };

            UserGetResponse userGetResponse = await _userService.LoginControl(userGetRequest);
            if (!userGetResponse.State)
            {
                response.GenerateErrorResponse(userGetResponse.ErrorMessage);
                return response;
            }

            if (!RateLimiter.IsAllowed(loginRequest.Username))
            {
                response.GenerateErrorResponse(MessageConstants.RATE_LIMIT_EXCEEDED);
                return response;

            }

            response.token_type = "Bearer";
            response.access_token = GenerateJwtToken(loginRequest.Username);
            response.expires_in = int.Parse(_configuration["Jwt:ExpiresInMinutes"]) * 60;
            response.GenerateSuccessResponse();

            return response;

        }
        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static class RateLimiter
        {

            private static readonly Dictionary<string, List<DateTime>> _request = new();

            public static bool IsAllowed(string key)
            {
                var now = DateTime.UtcNow;
                var windowStart = now.AddHours(-1);


                if (!_request.ContainsKey(key))
                    _request[key] = new List<DateTime>();

                _request[key] = _request[key].Where(t => t > windowStart).ToList();

                if (_request[key].Count >= 5)
                    return false;

                _request[key].Add(now);
                return true;
            }
        }


    }
}
