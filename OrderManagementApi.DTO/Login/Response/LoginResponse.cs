using OrderManagementApi.DTO.Base;

namespace OrderManagementApi.DTO.Login.Request
{
    public class LoginResponse : BaseResponse
    {
        
        public string token_type { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
