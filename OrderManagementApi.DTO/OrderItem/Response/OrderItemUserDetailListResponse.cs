using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.OrderItem.Dto;

namespace OrderManagementApi.DTO.OrderItem.Response
{
    public class OrderItemUserDetailListResponse : BaseResponse
    {
        public List<OrderItemUserDetailDto>? OrderItemUserDetails { get; set; }
    }
}