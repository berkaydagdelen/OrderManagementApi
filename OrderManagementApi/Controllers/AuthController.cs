using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.Login.Request;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;

        public AuthController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            LoginResponse loginResponse = await _loginService.Login(loginRequest);

            return Ok(loginResponse);
        }

    }
}
