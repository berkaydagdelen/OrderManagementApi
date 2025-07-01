using Microsoft.Extensions.Configuration;
using OrderManagementApi.DTO.Token.Dto;
using OrderManagementApi.Service.Abstract;
using System.Net.Http.Json;

namespace OrderManagementApi.Service.Service
{
    public class TokenCacheService : ITokenCacheService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private string _accessToken;
        private DateTime _tokenExpiry = DateTime.MinValue;

        public TokenCacheService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetToken()
        {
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _tokenExpiry)
                return _accessToken;

            var loginUrl = _configuration["Auth:LoginUrl"];
            var loginRequest = new
            {
                username = _configuration["Auth:Username"],
                password = _configuration["Auth:Password"]
            };

            var response = await _httpClient.PostAsJsonAsync(loginUrl, loginRequest);
            response.EnsureSuccessStatusCode();

            TokenResponse? tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.access_token))
                throw new Exception("Token alınamadı.");

            _accessToken = tokenResponse.access_token;
          
            _tokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in - 30);

            return _accessToken;
        }

    }


}
