using OrderManagementApi.DTO.Login.Request;

namespace OrderManagementApi.Service.Abstract
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);

    }
}
