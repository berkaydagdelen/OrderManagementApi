using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.OrderItem.Dto;

namespace OrderManagementApi.DTO.OrderItem.Response
{
    public class OrderItemDetailListResponse : BaseResponse
    {
        public List<OrderItemDetailDto>? OrderItemDetails { get; set; }
    }
}