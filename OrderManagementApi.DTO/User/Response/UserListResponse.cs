using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.User.Dto;

namespace OrderManagementApi.DTO.User.Response
{
    public class UserListResponse : BaseResponse
    {
        public List<UserDto>? Users { get; set; }
    }
} 